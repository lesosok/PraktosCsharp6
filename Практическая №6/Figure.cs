using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая__6
{
    public class Figure
    {
        public string figurename { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public Figure(string FigureName, int Width, int Height)
        {
            figurename = FigureName;
            width = Width;
            height = Height;
        }
        public Figure()
        {
        }
    }
}
