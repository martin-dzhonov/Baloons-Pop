using Baloons.Common.Field;
using System;
using System.Linq;

namespace Baloons.Common.Engine
{
    public class BaloonPopper
    {
        private int baloonsRemaining;
        private int[,] containerMatrixCopy;
        private int popsMade;
        
        public BaloonPopper(BaloonsContainer container)
        {
            this.containerMatrixCopy = new int[container.InnerMatrix.GetLength(0), container.InnerMatrix.GetLength(1)];
            Array.Copy(container.InnerMatrix, containerMatrixCopy, container.InnerMatrix.Length);
            baloonsRemaining = container.InnerMatrix.GetLength(0) * container.InnerMatrix.GetLength(1);
        }

        public bool AllPopped
        {
            get
            {
                return this.baloonsRemaining == 0;
            }
        }

        public int PopsMade
        {
            get
            {
                return this.popsMade;
            }
        }

        public int[,] Pop(int row, int col)
        {
            this.popsMade++;
            FindAndPop(row, col);
            FallDown();
            return this.containerMatrixCopy;
        }

        private void FindAndPop(int rowAtm, int columnAtm)
        {
            int searchedValue = containerMatrixCopy[rowAtm, columnAtm];
            baloonsRemaining--;
            containerMatrixCopy[rowAtm, columnAtm] = 0;
            GoLeft(rowAtm, columnAtm, searchedValue);
            GoRight(rowAtm, columnAtm, searchedValue);
            GoDown(rowAtm, columnAtm, searchedValue);
            GoUp(rowAtm, columnAtm, searchedValue);
        }

        private void FallDown()
        {
            int currRow = 0;
            for (int col = 0; col < containerMatrixCopy.GetLength(1); col++)
            {
                for (int row = containerMatrixCopy.GetLength(0) - 1; row > 0; row--)
                {
                    if (containerMatrixCopy[row, col] == 0)
                    {
                        currRow = row - 1;
                        while (currRow >= 0)
                        {
                            if (containerMatrixCopy[currRow, col] != 0)
                            {
                                containerMatrixCopy[row, col] = containerMatrixCopy[currRow, col];
                                containerMatrixCopy[currRow, col] = 0;
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
                if (containerMatrixCopy[newRow, newColumn] == searchedItem)
                {
                    containerMatrixCopy[newRow, newColumn] = 0;
                    baloonsRemaining--;
                    GoLeft(newRow, newColumn, searchedItem);
                }
                else
                {
                    return;
                }
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
                if (containerMatrixCopy[newRow, newColumn] == searchedItem)
                {
                    containerMatrixCopy[newRow, newColumn] = 0;
                    baloonsRemaining--;
                    GoRight(newRow, newColumn, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        private void GoDown(int row, int column, int searchedItem)
        {
            int newRow = row + 1;
            int newColumn = column;
            try
            {
                if (containerMatrixCopy[newRow, newColumn] == searchedItem)
                {
                    containerMatrixCopy[newRow, newColumn] = 0;
                    baloonsRemaining--;
                    GoDown(newRow, newColumn, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        private void GoUp(int row, int column, int searchedItem)
        {
            int newRow = row - 1;
            int newColumn = column;
            try
            {
                if (containerMatrixCopy[newRow, newColumn] == searchedItem)
                {
                    containerMatrixCopy[newRow, newColumn] = 0;
                    baloonsRemaining--;
                    GoUp(newRow, newColumn, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }
    }
}