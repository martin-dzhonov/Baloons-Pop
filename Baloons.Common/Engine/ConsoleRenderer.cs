using Baloons.Common.Enum;
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
        private readonly int fieldRows;
        private readonly int fieldCols;

        private readonly ConsoleColor indexersColor;
        private readonly ConsoleColor bordersColor;

        private const int MatrixTopOffset = 2;
        private const int MatrixLeftOffset = 4;

        public ConsoleRenderer()
        {
            fieldRows = (int)FieldDimensions.Height;
            fieldCols = (int)FieldDimensions.Width;
            
            indexersColor = ConsoleColor.White;
            bordersColor = ConsoleColor.Red;
        }

        private void WriteOnPosition(int row, int col, string symbol, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(col, row);
            Console.Write(symbol);
        }

        private ConsoleColor GetNumberColor(int num)
        {
            switch (num)
            {
                case 1:
                    return ConsoleColor.Red;
                case 2:
                    return ConsoleColor.Yellow;
                case 3:
                    return ConsoleColor.Blue;
                case 4:
                    return ConsoleColor.Cyan;
                default:
                    throw new ArgumentException();
            }
        }

        public void RenderOutlines()
        {
            int counter = 0;
            
            //print column indexers          
            int colIndexersStartCol = 4;
            for (int i = colIndexersStartCol; i < fieldCols - 1; i++)
            {
                if (i % 2 == 0)
                {
                    WriteOnPosition(0, i, counter.ToString(), indexersColor);
                    counter++;
                }
            }
            counter = 0;

            //print row indexers
            int rowIndexersStartRow = 2;
            for (int i = rowIndexersStartRow; i < fieldRows - 1; i++)
            {
                WriteOnPosition(i, 0, counter.ToString(), indexersColor);
                counter++;
            }

            //print horizontal borders
            int bordersStartCol = colIndexersStartCol - 1;
            int topBorderRow = 1;
            int bottomBorderRow = fieldRows - 1;
            for (int i = bordersStartCol; i < fieldCols - 1; i++)
            {
                WriteOnPosition(topBorderRow, i, "-", bordersColor);
                WriteOnPosition(bottomBorderRow, i, "-", bordersColor);
            }

            //print vertical borders
            int bordersStartRow = rowIndexersStartRow;
            int leftBorderCol = 2;
            int rightBorderCol = fieldCols - 1;
            for (int i = bordersStartRow; i < fieldRows - 1; i++)
            {
                WriteOnPosition(i, leftBorderCol, "|", bordersColor);
                WriteOnPosition(i, rightBorderCol, "|", bordersColor);
            }
        }
        
        public void RenderMatrix(IRenderable obj)
        {
            int matrixFinishRow = fieldRows - 1;
            int matrixFinishCol = fieldCols - 2;

            char[,] image = obj.GetImage();
            for (int i = 0; i < image.GetLength(0); i++)
            {
                int currPrintRow = i + MatrixTopOffset;
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    int currPrintCol = (j * 2) + MatrixLeftOffset;
                    int currNum = (int)Char.GetNumericValue(image[i, j]);
                    ConsoleColor currColor = GetNumberColor(currNum);
                    WriteOnPosition(currPrintRow, currPrintCol, currNum.ToString(), currColor);
                }
            }
        }

        public void RenderText(params string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                WriteOnPosition(fieldRows + 1, 0, words[i], ConsoleColor.Green);
            }
        }
    }
}