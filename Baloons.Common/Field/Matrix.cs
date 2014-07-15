using Baloons.Common.Enum;
using Baloons.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baloons.Common.Field
{
    class Matrix : IRenderable
    {
        private byte[,] innerMatrix;
        private char[,] image;

        private int rows;
        private int cols;
        public Matrix()
        {
            rows = (int)MatrixDimensions.Height;
            cols = (int)MatrixDimensions.Width;

            innerMatrix = this.GenerateInner();
            image = this.GenerateImage(innerMatrix);
        }

        public char[,] GetImage()
        {
            return this.image;
        }

        public byte[,] InnerMatrix
        {
            get
            {
                return this.innerMatrix;
            }
        }

        private byte[,] GenerateInner()
        {

            byte[,] numbersMatrix = new byte[this.rows, this.cols];
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

        private char[,] GenerateImage(byte[,] innerMatrix)
        {
            char[,] image = new char[this.rows, this.cols];
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    image[row, col] = innerMatrix[row, col].ToString()[0];
                }
            }
            return image;
        }

    }
}
