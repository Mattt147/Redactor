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
        Bitmap Redact(Bitmap image);
    }



    public class GrayscaleStrategy : IRedactorStrategy
    {
        public Bitmap Redact(Bitmap image)
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




    public class ResizeStrategy : IRedactorStrategy
    {
        private int _newWidth;
        private int _newHeight;

        public ResizeStrategy(int newWidth, int newHeight)
        {
            _newWidth = newWidth;
            _newHeight = newHeight;
        }

        public Bitmap Redact(Bitmap image)
        {
            return new Bitmap(image, new Size(_newWidth, _newHeight));
        }
    }




    public class ContrastStrategy : IRedactorStrategy
    {
        private float contrastLevel;

        public ContrastStrategy(float contrastLevel)
        {
            this.contrastLevel = contrastLevel;
        }

        public Bitmap Redact(Bitmap image)
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



}
