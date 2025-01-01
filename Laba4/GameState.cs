using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4
{
    public class GameState
    {
        public Ball Ball { get; set; } = new Ball(400, 250, 5, 5, 17);
        public Paddle PlayerPaddle { get; set; } = new Paddle(15, 200, 30, 100, false); 
        public Paddle ComputerPaddle { get; set; } = new Paddle(750, 200, 30, 100, true); 
        public bool ComputerPaddleSubscribed { get; set; } = false;
        public Score Score { get; set; } = new Score();

        public void UpdateLocations()
        {
            Ball.PictureBox.Location = new Point(Ball.X, Ball.Y);
            PlayerPaddle.PictureBox.Location = new Point(PlayerPaddle.X, PlayerPaddle.Y);
            ComputerPaddle.PictureBox.Location = new Point(ComputerPaddle.X, ComputerPaddle.Y);
        }
    }
}
