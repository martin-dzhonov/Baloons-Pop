using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Baloons.Common.Field;

namespace Baloons.Test.EngineTests
{
    [TestClass]
    public class BaloonContainerTests
    {
        [TestMethod]
        public void InnerMatrixGeneratedRight()
        {
            BaloonsContainer container = new BaloonsContainer();
            for (int i = 0; i < container.InnerMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < container.InnerMatrix.GetLength(1); j++)
                {
                    Assert.IsFalse(container.InnerMatrix[i, j] == 0);
                }
            }
        }

        [TestMethod]
        public void InnerMatrixIndenticalToImage()
        {
            BaloonsContainer container = new BaloonsContainer();
            int[,] innerMatrix = container.InnerMatrix;
            char[,] image = container.GetImage();

            for (int i = 0; i < container.InnerMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < container.InnerMatrix.GetLength(1); j++)
                {
                    Assert.AreEqual(Char.GetNumericValue(image[i, j]), innerMatrix[i, j]);
                }
            }
        }
    }
}