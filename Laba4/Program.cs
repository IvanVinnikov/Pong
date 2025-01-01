using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var gameState = new GameState();
            var gameView = new GameView(gameState);
            var gameController = new GameController(gameState, gameView);

            gameController.StartTimer();
            Application.Run(gameView);
        }
    }
}
