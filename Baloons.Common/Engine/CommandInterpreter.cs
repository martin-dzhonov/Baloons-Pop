using System;
using System.Linq;

namespace Baloons.Common.Engine
{
    using Baloons.Common.Enum;
    using Baloons.Common.Field;

    public class CommandInterpreter
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
            this.InitField();
        }

        public void ValidateAndDispatch(string command)
        {
            var commandWords = command.ToLower().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            bool isComandValid = false;

            if (commandWords.Length == 1)
            {
                if (commandWords[0] == "restart" || commandWords[0] == "exit" || commandWords[0] == "init")
                {
                    isComandValid = true;
                }
            }

            if (commandWords.Length == 3)
            {
                if (IsValidPopCommand(commandWords))
                {
                    isComandValid = true;
                }
            }

            if (isComandValid)
            {
                DispatchCommand(commandWords);
            }
            else if (commandWords.Length != 0)
            {
                renderer.RenderText("Invalid input !", "*Press any key to continue*");
                Console.ReadKey();
            }
            
            this.CheckForWin();
            
            renderer.RenderText("Command: ");
        }

        private void DispatchCommand(string[] commandWords)
        {
            switch (commandWords[0])
            {
                case "init":
                    this.InitField();
                    break;
                case "restart":
                    this.HandleRestartCommand();
                    break;
                case "exit":
                    this.HandleExitCommand();
                    break;
                case "pop":
                    this.HandlePopCommand(commandWords);
                    break;
            }
        }

        private void InitField()
        {
            this.container = new BaloonsContainer();
            this.popper = new BaloonPopper(container);
            containerMatrixCopy = new int[container.InnerMatrix.GetLength(0), container.InnerMatrix.GetLength(1)];
            Array.Copy(container.InnerMatrix, containerMatrixCopy, container.InnerMatrix.Length);
            renderer.RenderField(container);
        }

        private void HandleRestartCommand()
        {
            Array.Copy(containerMatrixCopy, container.InnerMatrix, containerMatrixCopy.Length);
            this.popper = new BaloonPopper(container);
            renderer.RenderContainer(container);
        }

        private void HandleExitCommand()
        {
            renderer.RenderText("Thank you for playing !", "*Press any key to exit*");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private bool IsValidPopCommand(string[] words)
        {
            if (words.Length == 3)
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
                            if (container.InnerMatrix[rowCoords, colCoords] != 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void HandlePopCommand(string[] commandWords)
        {
            int rowCoords = Convert.ToInt32(commandWords[1]);
            int colCoords = Convert.ToInt32(commandWords[2]);
            container.InnerMatrix = popper.Pop(rowCoords, colCoords);
            renderer.RenderContainer(container);
        }

        private void CheckForWin()
        {
            if (this.popper.AllPopped)
            {
                renderer.RenderText("You win !", "You finished in " + popper.PopsMade + "moves", "*Press any key to exit*");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}