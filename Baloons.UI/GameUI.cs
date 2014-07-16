using Baloons.Common;
using Baloons.Common.Engine;
namespace Baloons.UI
{
    class GameUI
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine();
            Engine engine = Engine.Instance;
            engine.Run();

        }
    }
}
