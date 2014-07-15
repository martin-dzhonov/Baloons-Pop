using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baloons.Common.Interfaces;
using Baloons.Common.Enum;
namespace Baloons.Common
{
    public class InnerField : IRenderable
    {
        private byte[,] numbersMatrix;
        public InnerField()
        {
            this.numbersMatrix = this.Generate();
        }

        
        public byte[,] GetMatrix
        {
            get
            {
                return this.numbersMatrix;
            }
        }

        private byte[,] Generate()
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
            char[,] charMatrix = new char[(int)FieldDimensions.Height, (int)FieldDimensions.Width];
            for (int i = 0; i < charMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < charMatrix.GetLength(1); j++)
                {
                    charMatrix[i, j] = Convert.ToChar(numbersMatrix[i, j]);
                }
            }
            return charMatrix;
        }
    }
}