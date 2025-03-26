using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{   

    /// <summary>
    /// Стратегия для увиличения и уменьшениея яркости картинки.
    /// </summary>
    public class BrigthtnessStrategy : IRedactorStrategy
    {
        private float brightnessFactor;

        
        public BrigthtnessStrategy(float brightnessFactor)
        {
            this.brightnessFactor = brightnessFactor;
        }



        /// <summary>
        ///  Метод уменьшающий и увиличивающий яркость картинки
        /// </summary>
        /// <param name="image">изначальная картинка</param>
        /// <returns>итоговую картинку</returns>
        public Bitmap Edit(Bitmap image)
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);

                    int r = (int)(pixelColor.R * brightnessFactor);
                    int g = (int)(pixelColor.G * brightnessFactor);
                    int b = (int)(pixelColor.B * brightnessFactor);

                    r = Math.Min(255, Math.Max(0, r));
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    newImage.SetPixel(x, y, Color.FromArgb(pixelColor.A, r, g, b));
                }
            }

            return newImage;
        }

    }
}
