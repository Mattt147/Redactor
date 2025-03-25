using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Editor
    {
        IRedactorStrategy strategy;
        public Editor(IRedactorStrategy strategy)
        {
            this.strategy = strategy;
        }

        public Bitmap Edit(Bitmap bm)
        {
            Bitmap res = strategy.Edit(bm);
            return res;
        }
    }
}
