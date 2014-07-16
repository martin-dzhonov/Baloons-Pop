using Baloons.Common.Enum;
using Baloons.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baloons.Common.Field
{
   public class BaloonsContainer : IRenderable
    {
        private int[,] innerMatrix;
        private char[,] image;

        private readonly int rows;
        private readonly int cols;

        public BaloonsContainer()
        {
            rows = (int)MatrixDimensions.Height;
            cols = (int)MatrixDimensions.Width;

            innerMatrix = this.GenerateInner();
            image = this.GenerateImage(innerMatrix);
        }

        public char[,] GetImage()
        {
            this.image = GenerateImage(innerMatrix);
            return this.image;
        }

        public int[,] InnerMatrix
        {
            get
            {
                return this.innerMatrix;
            }
            set
            {
                this.innerMatrix = value;
            }
        }

        private int[,] GenerateInner()
        {
            int[,] numbersMatrix = new int[this.rows, this.cols];
            Random rnd = new Random();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int randomNum = rnd.Next(1, 5);
                    numbersMatrix[row, col] = randomNum;
                }
            }
            return numbersMatrix;
        }

        private char[,] GenerateImage(int[,] innerMatrix)
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