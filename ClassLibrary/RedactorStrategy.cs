using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ClassLibrary
{   


    /// <summary>
    /// Интерфейс для стратегий наложения фильтров на картинку.
    /// </summary>
    public interface IRedactorStrategy
    {
        Bitmap Edit(Bitmap image);
    }


}
