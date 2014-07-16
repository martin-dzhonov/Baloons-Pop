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
        private int[,] ballonsMatrixCopy;
        private int moves;
        
        public BaloonPopper(BaloonsContainer container)
        {
            this.ballonsMatrixCopy = new int[container.InnerMatrix.GetLength(0), container.InnerMatrix.GetLength(1)];
            Array.Copy(container.InnerMatrix, ballonsMatrixCopy, container.InnerMatrix.Length);
            baloonsRemaining = container.InnerMatrix.GetLength(0) * container.InnerMatrix.GetLength(1);
        }

        public bool AllPopped
        {
            get
            {
                return this.baloonsRemaining == 0;
            }
        }

        public int Moves
        {
            get
            {
                return this.moves;
            }
        }

        public int[,] Pop(int row, int col)
        {
            this.moves++;
            FindAndPop(row, col);
            FallDown();
            return this.ballonsMatrixCopy;
        }


        private void FindAndPop(int rowAtm, int columnAtm)
        {
            int searchedValue = ballonsMatrixCopy[rowAtm, columnAtm];
            ballonsMatrixCopy[rowAtm, columnAtm] = 0;
            GoLeft(rowAtm, columnAtm, searchedValue);
            GoRight(rowAtm, columnAtm, searchedValue);
            GoUp(rowAtm, columnAtm, searchedValue);
            GoDown(rowAtm, columnAtm, searchedValue);
        }

        private void FallDown()
        {
            int currRow = 0;
            for (int col = 0; col < ballonsMatrixCopy.GetLength(1); col++)
            {
                for (int row = ballonsMatrixCopy.GetLength(0) - 1; row > 0; row--)
                {
                    if (ballonsMatrixCopy[row, col] == 0)
                    {
                        currRow = row - 1;
                        while (currRow >= 0)
                        {
                            if (ballonsMatrixCopy[currRow, col] != 0)
                            {
                                ballonsMatrixCopy[row, col] = ballonsMatrixCopy[currRow, col];
                                ballonsMatrixCopy[currRow, col] = 0;
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
                if (ballonsMatrixCopy[newRow, newColumn] == searchedItem)
                {
                    ballonsMatrixCopy[newRow, newColumn] = 0;
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
                if (ballonsMatrixCopy[newRow, newColumn] == searchedItem)
                {
                    ballonsMatrixCopy[newRow, newColumn] = 0;
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
                if (ballonsMatrixCopy[newRow, newColumn] == searchedItem)
                {
                    ballonsMatrixCopy[newRow, newColumn] = 0;
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
                if (ballonsMatrixCopy[newRow, newColumn] == searchedItem)
                {
                    ballonsMatrixCopy[newRow, newColumn] = 0;
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
    }
}