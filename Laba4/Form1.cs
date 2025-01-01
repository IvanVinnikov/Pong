using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laba4
{
    public partial class GameView : Form
    {
        public GameState _state;

        public GameView(GameState state)
        {
            _state = state;
            this.DoubleBuffered = true;
            this.Width = 800;
            this.Height = 530;
            this.BackgroundImage = Image.FromFile("bg.jpg");
            this.Text = "Player - 0 | Computer - 0";
            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            // Ball PictureBox
            _state.Ball.PictureBox = new PictureBox
            {
                Width = _state.Ball.Radius * 2,
                Height = _state.Ball.Radius * 2,
                BackColor = Color.Transparent,
                Location = new Point(_state.Ball.X, _state.Ball.Y),
                Image = Image.FromFile("ball.png")
            };
            this.Controls.Add(_state.Ball.PictureBox);

            // Player Paddle PictureBox
            _state.PlayerPaddle.PictureBox = new PictureBox
            {
                Width = _state.PlayerPaddle.Width,
                Height = _state.PlayerPaddle.Height,
                BackColor = Color.Transparent,
                Location = new Point(_state.PlayerPaddle.X, _state.PlayerPaddle.Y),
                Image = Image.FromFile("paddle.jpg")
            };
            this.Controls.Add(_state.PlayerPaddle.PictureBox);

            _state.ComputerPaddle.PictureBox = new PictureBox
            {
                Width = _state.ComputerPaddle.Width,
                Height = _state.ComputerPaddle.Height,
                BackColor = Color.Transparent,
                Location = new Point(_state.ComputerPaddle.X, _state.ComputerPaddle.Y),
                Image = Image.FromFile("paddle.jpg")
            };
            this.Controls.Add(_state.ComputerPaddle.PictureBox);

        }

        public void UpdateView()
        {
            _state.UpdateLocations();
        }

    }

}
