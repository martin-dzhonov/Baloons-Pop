using Baloons.Common.Enum;
using Baloons.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baloons.Common.Field
{
    class Field : IRenderable
    {
        private byte[,] innerMatrix;
        private char[,] outterImage;

        private int rows;
        private int cols;
        public Field()
        {
            rows = (int)FieldDimensions.Height;
            cols = (int)FieldDimensions.Width;

            innerMatrix = this.GenerateInner();
            outterImage = this.GenerateOuter();
        }

        public byte[,] InnerMatrix
        {
            get
            {
                return this.innerMatrix;
            }
        }

        private char[,] GenerateOuter()
        {
            int outterRows = rows + 3;
            int outterCols = cols + 3;
            char[,] charsMatrix = new char[outterRows, outterCols];

            for (int i = 2; i < outterCols - 1; i++)
            {
                charsMatrix[0, i] = '1';
            }
            for (int i = 2; i < outterRows - 1; i++)
            {
                charsMatrix[i, 0] = '1';
               
            }
            return charsMatrix;
        }
        private byte[,] GenerateInner()
        {
            int rows = (int)FieldDimensions.Height;
            int cols = (int)FieldDimensions.Width;
            byte[,] numbersMatrix = new byte[rows, cols];
            Random rnd = new Random();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    byte randomNum = (byte)rnd.Next(1, 5);
                    numbersMatrix[row, col] = randomNum;
                }
            }
            return numbersMatrix;
        }

        public char[,] GetImage()
        {
            return outterImage;
        }
    }
}
