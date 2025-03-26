using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{


    /// <summary>
    /// Cтратегия для применения фильтра "Винтаж". 
    /// </summary>
    public class VintageEffectStrategy : IRedactorStrategy
    {



        /// <summary>
        /// Метод для применения фильтра "Винтаж"
        /// </summary>
        /// <param name="originalImage">изначальная картинка</param>
        /// <returns>итоговая картинка</returns>
        public Bitmap Edit(Bitmap originalImage)
        {
            Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);


            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);

                    //затемнение
                    int r = (int)(originalColor.R * 0.85);
                    int g = (int)(originalColor.G * 0.75);
                    int b = (int)(originalColor.B * 0.65);

                    addNoise(ref r, ref g, ref b);

                    Color newColor = Color.FromArgb(originalColor.A, r, g, b);
                    newImage.SetPixel(x, y, newColor);
                }
            }
            addTextures(ref newImage);
            

            return newImage;
        }


       private void addNoise(ref int r, ref int g , ref int b)
       {
            Random random = new Random();
            int noiseR = random.Next(-70, 70);
            int noiseG = random.Next(-70, 70);
            int noiseB = random.Next(-70, 70);

            r = Math.Clamp(r + noiseR, 0, 255);
            g = Math.Clamp(g + noiseG, 0, 255);
            b = Math.Clamp(b + noiseB, 0, 255);
       }
        
        private void addTextures(ref Bitmap newImage)
        {
            Bitmap overlayImage = new Bitmap("C:/Users/matve/source/repos/Redactor/scr.png");

            Bitmap resizedOverlayImage = new Bitmap(overlayImage, newImage.Size);

            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(resizedOverlayImage, 0, 0);
            }

        }




    }
}
