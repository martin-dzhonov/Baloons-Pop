using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Baloons.Common.Engine;
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

            Assert.AreEqual(image.GetLength(0), innerMatrix.GetLength(0));
            Assert.AreEqual(image.GetLength(1), innerMatrix.GetLength(1));

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