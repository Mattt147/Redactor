using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    


    /// <summary>
    /// Стратегия для уменьшения и увиличения контраста картинки.
    /// </summary>
    public class ContrastStrategy : IRedactorStrategy
    {
        private float contrastLevel;

        public ContrastStrategy(float contrastLevel)
        {
            this.contrastLevel = contrastLevel;
        }



        /// <summary>
        /// Метод уменьшающий и увиличивающий контраст картинки.
        /// </summary>
        /// <param name="image">изначальная картинка</param>
        /// <returns>итоговая картинка</returns> 
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
}
