using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baloons.Common.Engine
{
    using Baloons.Common.Enum;
    using Baloons.Common.Field;

    internal class CommandInterpreter
    {
        private Matrix matrix;
        private ConsoleRenderer renderer;
        private Matrix startMatrix;
        private BaloonPopper popper;

        public CommandInterpreter()
        {
            Console.WindowWidth = 75;
            Console.BufferWidth = 75;
            Console.WindowHeight = 25;
            Console.BufferHeight = 25;
            
            this.renderer = new ConsoleRenderer();
            InitField();
            popper = new BaloonPopper();
        }

        public void ExecuteComand(string command)
        {
            var commandWords = command.ToLower().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (commandWords.Length == 1)
            {
                if (commandWords[0] == "init")
                {
                    this.HandleInitCommand();
                }
                else if (commandWords[0] == "restart")
                {
                    this.HandleRestartCommand();
                }
                else if (commandWords[0] == "exit")
                {
                    this.HandleExitCommand();
                }
                else
                {
                    renderer.RenderText("Invalid input !", "*Press any key to continue*");
                    Console.ReadKey();
                }
            }
            else if (commandWords.Length == 3)
            {
                if (IsValidPopCommand(commandWords))
                {
                    int rowCoords = Convert.ToInt32(commandWords[1]);
                    int colCoords = Convert.ToInt32(commandWords[2]);
                    this.popper.Pop(matrix, rowCoords, colCoords);
                    renderer.RenderField(matrix);
                }
                else
                {
                    renderer.RenderText("Invalid input !", "*Press any key to continue*");
                    Console.ReadKey();
                }
            }
            else
            {
                renderer.RenderText("Invalid input !", "*Press any key to continue*");
                Console.ReadKey();
            }
            
            renderer.RenderText("Command: ");
        }

        private bool IsValidPopCommand(string[] words)
        {
            if (words[0] == "pop")
            {
                int num = 0;
                bool firstCoordValid = Int32.TryParse(words[1], out num);
                bool secondCoordValid = Int32.TryParse(words[2], out num);
                if (firstCoordValid && secondCoordValid)
                {
                    int rowCoords = Int32.Parse(words[1]);
                    int colCoords = Int32.Parse(words[2]);
                    if ((rowCoords >= 0 && colCoords >= 0) &&
                        (rowCoords < (int)MatrixDimensions.Width &&
                         colCoords < (int)MatrixDimensions.Height))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void HandleInitCommand()
        {
            InitField();
            renderer.RenderField(matrix);
        }

        private void HandleRestartCommand()
        {
            this.matrix = startMatrix;
            renderer.RenderField(matrix);
        }

        private void HandleExitCommand()
        {
            renderer.RenderText("Thank you for playing !", "*Press any key to exit*");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private void InitField()
        {
            this.matrix = new Matrix();
            this.startMatrix = matrix;
        }
    }
}