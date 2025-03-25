using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ClassLibrary
{   



    public interface IRedactorStrategy
    {
        Bitmap Edit(Bitmap image);
    }



    /// <summary>
    /// 
    /// </summary>
    public class GrayscaleStrategy : IRedactorStrategy
    {
        public Bitmap Edit(Bitmap image)
        {
            Bitmap grayscaleImage = new Bitmap(image.Width, image.Height);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    grayscaleImage.SetPixel(x, y, grayColor);

                }
            }
            return grayscaleImage;
        }
    }




    /// <summary>
    /// 
    /// </summary>
    public class ContrastStrategy : IRedactorStrategy
    {
        private float contrastLevel;

        public ContrastStrategy(float contrastLevel)
        {
            this.contrastLevel = contrastLevel;
        }

        public Bitmap Edit(Bitmap image)
        {
            Bitmap contrastedImage = new Bitmap(image.Width, image.Height);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int r = Clamp((int)((pixel.R - 128) * contrastLevel + 128));
                    int g = Clamp((int)((pixel.G - 128) * contrastLevel + 128));
                    int b = Clamp((int)((pixel.B - 128) * contrastLevel + 128));

                    contrastedImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return contrastedImage;
        }

        private int Clamp(int value)
        {
            return Math.Max(0, Math.Min(255, value));
        }
    }



    public class RetroFilter : IRedactorStrategy
    {
        public Bitmap Edit(Bitmap original)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixel = original.GetPixel(x, y);

                    // эффект ретро
                    int r = Math.Min(255, (int)(pixel.R * 0.9)); 
                    int g = Math.Min(255, (int)(pixel.G * 0.5)); 
                    int b = Math.Min(255, (int)(pixel.B * 0.5)); 

                    Color newColor = Color.FromArgb(r, g, b);
                    result.SetPixel(x, y, newColor);
                }
            }

            return result;
        }
    }




    public class VintageEffectStrategy : IRedactorStrategy
    {
    public Bitmap Edit(Bitmap originalImage)
    {
        Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);
        
        for (int y = 0; y < originalImage.Height; y++)
        {
            for (int x = 0; x < originalImage.Width; x++)
            {
                Color originalColor = originalImage.GetPixel(x, y);
                
                int r = (int)(originalColor.R * 0.9);
                int g = (int)(originalColor.G * 0.6);
                int b = (int)(originalColor.B * 0.4);
                
                int noise = new Random().Next(-10, 10);
                r = Math.Clamp(r + noise, 0, 255);
                g = Math.Clamp(g + noise, 0, 255);
                b = Math.Clamp(b + noise, 0, 255);

                Color newColor = Color.FromArgb(originalColor.A, r, g, b);
                newImage.SetPixel(x, y, newColor);
            }
        }

        return newImage;
    }
}

}
