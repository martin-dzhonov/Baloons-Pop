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
        private BaloonsContainer container;   
        private ConsoleRenderer renderer;       
        private BaloonPopper popper;
        private int[,] containerMatrixCopy;
        public CommandInterpreter()
        {
            Console.WindowWidth = 75;
            Console.BufferWidth = 75;
            Console.WindowHeight = 25;
            Console.BufferHeight = 25;
            
            this.renderer = new ConsoleRenderer();
            InitField();
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
                    HandlePopCommand(commandWords);
                }
                else
                {
                    renderer.RenderText("Invalid input !", "*Press any key to continue*");
                    Console.ReadKey();
                }
            }
            
            else if(commandWords.Length != 0)
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
                        (rowCoords < (int)MatrixDimensions.Height &&
                         colCoords < (int)MatrixDimensions.Width))
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

        private void HandlePopCommand(string[] commandWords)
        {
            int rowCoords = Convert.ToInt32(commandWords[1]);
            int colCoords = Convert.ToInt32(commandWords[2]);
            container.InnerMatrix = popper.Pop(rowCoords, colCoords);
            renderer.RenderField(container);
        }

        private void HandleInitCommand()
        {
            InitField();
            renderer.RenderField(container);
        }

        private void HandleRestartCommand()
        {
            Array.Copy(containerMatrixCopy, container.InnerMatrix, containerMatrixCopy.Length);
            this.popper = new BaloonPopper(container);
            renderer.RenderField(container);
        }

        private void HandleExitCommand()
        {
            renderer.RenderText("Thank you for playing !", "*Press any key to exit*");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private void InitField()
        {
            this.container = new BaloonsContainer();
            this.popper = new BaloonPopper(container);
            containerMatrixCopy = new int[container.InnerMatrix.GetLength(0), container.InnerMatrix.GetLength(1)];
            Array.Copy(container.InnerMatrix, containerMatrixCopy, container.InnerMatrix.Length);
            renderer.RenderField(container);
        }
    }
}