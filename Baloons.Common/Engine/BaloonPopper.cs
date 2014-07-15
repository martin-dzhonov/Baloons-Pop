using Baloons.Common.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baloons.Common.Engine
{
    class BaloonPopper
    {
      

        public BaloonPopper()
        {
        }

        public void Pop(Matrix matrix ,int row, int col)
        {
        
            FindAndPop(matrix, row, col, matrix.InnerMatrix[row, col]);
        }

        private void FindAndPop(Matrix matrix, int row, int col, int searchedValue)
        {
            if (col < 0 || row < 0 ||
                col >= matrix.InnerMatrix.GetLength(1) || row >= matrix.InnerMatrix.GetLength(0) ||
                matrix.InnerMatrix[row, col] != searchedValue)
            {
                return;
            }

            if (matrix.InnerMatrix[row, col] == searchedValue)
            {
                matrix.InnerMatrix[row, col] = 0;

                FindAndPop(matrix, row - 1, col, searchedValue);
                FindAndPop(matrix, row, col + 1, searchedValue);
                FindAndPop(matrix, row + 1, col, searchedValue);
                FindAndPop(matrix, row, col - 1, searchedValue);
            }
        }
    }
}