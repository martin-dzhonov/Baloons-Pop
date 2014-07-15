using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baloons.Common.Interfaces
{
    interface IRenderable
    {
        char[,] GetImage();
    }
}
