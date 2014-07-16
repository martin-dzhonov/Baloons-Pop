using Baloons.Common.Enum;
using Baloons.Common.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baloons.Common.Engine
{
    public class BaloonPopper
    {
        private int baloonsRemaining;
        private int[,] matrixToModify;

        public BaloonPopper(BaloonsContainer container)
        {
            this.matrixToModify = new int[container.InnerMatrix.GetLength(0), container.InnerMatrix.GetLength(1)];
            Array.Copy(container.InnerMatrix, matrixToModify, container.InnerMatrix.Length);
            baloonsRemaining = container.InnerMatrix.GetLength(0) * container.InnerMatrix.GetLength(1);
        }

        public int[,] Pop(int row, int col)
        {
            FindAndPop(row, col);
            FallDown();
            return this.matrixToModify;
        }
        public void FallDown()
        {
            int currRow = 0;
            for (int col = 0; col < matrixToModify.GetLength(1); col++)
            {
                for (int row = matrixToModify.GetLength(0) - 1; row > 0; row--)
                {
                    if (matrixToModify[row, col] == 0)
                    {
                        currRow = row - 1;
                        while (currRow >= 0)
                        {
                            if (matrixToModify[currRow, col] != 0)
                            {
                                matrixToModify[row, col] = matrixToModify[currRow, col];
                                matrixToModify[currRow, col] = 0;
                                break;
                            }
                            else
                            {
                                currRow--;
                            }
                        }
                    }
                }
            }
        }

        private void GoLeft(int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column - 1;
            try
            {
                if (matrixToModify[newRow, newColumn] == searchedItem)
                {
                    matrixToModify[newRow, newColumn] = 0;
                    GoLeft(newRow, newColumn, searchedItem);
                }
                else
                    return;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        private void GoRight(int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column + 1;
            try
            {
                if (matrixToModify[newRow, newColumn] == searchedItem)
                {
                    matrixToModify[newRow, newColumn] = 0;
                    GoRight(newRow, newColumn, searchedItem);
                }
                else
                    return;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        private void GoUp(int row, int column, int searchedItem)
        {
            int newRow = row + 1;
            int newColumn = column;
            try
            {
                if (matrixToModify[newRow, newColumn] == searchedItem)
                {
                    matrixToModify[newRow, newColumn] = 0;
                    GoUp(newRow, newColumn, searchedItem);
                }
                else
                    return;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        private void GoDown(int row, int column, int searchedItem)
        {
            int newRow = row - 1;
            int newColumn = column;
            try
            {
                if (matrixToModify[newRow, newColumn] == searchedItem)
                {
                    matrixToModify[newRow, newColumn] = 0;
                    GoDown(newRow, newColumn, searchedItem);
                }
                else
                    return;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        private void FindAndPop(int rowAtm, int columnAtm)
        {
            int searchedValue = matrixToModify[rowAtm, columnAtm];
            matrixToModify[rowAtm, columnAtm] = 0;
            GoLeft(rowAtm, columnAtm, searchedValue);
            GoRight(rowAtm, columnAtm, searchedValue);
            GoUp(rowAtm, columnAtm, searchedValue);
            GoDown(rowAtm, columnAtm, searchedValue);
        }

        
    }
}