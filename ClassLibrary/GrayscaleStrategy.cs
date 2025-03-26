using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{

    /// <summary>
    /// Cтратегия для применения фильтра "ЧБ". 
    /// </summary>
    public class GrayscaleStrategy : IRedactorStrategy
    {



        /// <summary>
        /// Метод применяющий фильтр ЧБ
        /// </summary>
        /// <param name="image">изначальная картинка</param>
        /// <returns>итоговая картинка</returns> 
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
}

