using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{

    /// <summary>
    /// Cтратегия для применения фильтра "негатив". 
    /// </summary>
    public class NegativeStrategy : IRedactorStrategy
    {
        private float brightnessFactor;


        /// <summary>
        /// Метод применяющий фильтр "Негатив"
        /// </summary>
        /// <param name="original">изначальная картинка</param>
        /// <returns>итоговая картинка</returns>
        public Bitmap Edit(Bitmap original)
        {
            // Создаем новый битмап такой же ширины и высоты, что и оригинал
            Bitmap negativeImage = new Bitmap(original.Width, original.Height);

            // Проходим по каждому пикселю
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    // Получаем цвет пикселя
                    Color pixelColor = original.GetPixel(x, y);

                    // Инвертируем цвета
                    int r = 255 - pixelColor.R;
                    int g = 255 - pixelColor.G;
                    int b = 255 - pixelColor.B;

                    // Устанавливаем новый цвет в негативное изображение
                    negativeImage.SetPixel(x, y, Color.FromArgb(pixelColor.A, r, g, b));
                }
            }

            return negativeImage; // Возвращаем созданное негативное изображение
        }


    }
}
