using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Baloons.Common.Engine
{
    using Baloons.Common.Field;
    class CommandInterpreter
    {
        private Matrix field;
        private ConsoleRenderer renderer;
        public CommandInterpreter()
        {
            this.field = new Matrix();
            this.renderer = new ConsoleRenderer();
        }
        public void ExecuteComand(string command)
        {
            if (command == "init")
            {
                renderer.RenderOutlines();
                renderer.RenderMatrix(field);
            }
        }

    }
}
