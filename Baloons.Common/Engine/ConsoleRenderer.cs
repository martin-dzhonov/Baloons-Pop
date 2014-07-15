using Baloons.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baloons.Common.Engine
{
    class ConsoleRenderer
    {
        public void Render(IRenderable obj)
        {
            var image = obj.GetImage();
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    string currSymbol = image[i, j].ToString();
                    WriteOnPosition(i, j, currSymbol, ConsoleColor.Green);
                }
            }
        }

        private void WriteOnPosition(int row, int col, string symbol, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(col, row);
            Console.Write(symbol);
        }
    }
}
