using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Laba4
{
    public class Ball : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>(); 

        public int X { get; set; }
        public int Y { get; set; }
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }
        public int Radius { get; set; }
        public PictureBox PictureBox { get; set; }

        public Ball(int startX, int startY, int speedX, int speedY, int radius)
        {
            X = startX;
            Y = startY;
            SpeedX = speedX;
            SpeedY = speedY;
            Radius = radius;
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(Y); 
            }
        }

        public void Move()
        {
            X += SpeedX;
            Y += SpeedY;

            if (X > 400)
            {
                Notify();
            }
        }
        public void HandleWallCollision(int height)
        {
            if (Y <= 0 || Y + Radius * 2 >= height)
            {
                SpeedY = -SpeedY;
            }
        }

        public void HandlePaddleCollision(Paddle playerPaddle, Paddle computerPaddle)
        {
            if (X <= playerPaddle.X + playerPaddle.Width &&
                X + Radius >= playerPaddle.X &&
                Y + Radius >= playerPaddle.Y &&
                Y <= playerPaddle.Y + playerPaddle.Height)
            {
                SpeedX = Math.Abs(SpeedX) + 1; 
            }

            if (X + Radius * 2 >= computerPaddle.X &&
                X <= computerPaddle.X + computerPaddle.Width &&
                Y + Radius >= computerPaddle.Y &&
                Y <= computerPaddle.Y + computerPaddle.Height)
            {
                SpeedX = -Math.Abs(SpeedX) - 1; 
            }
        }


        public void CheckSideCollision(int width, Score score, GameController controller)
        {
            if (X <= 0)
            {
                score.IncrementComputerScore(controller);
                ResetPosition(width / 2, 250);
            }
            else if (X + Radius * 2 >= width)
            {
                score.IncrementPlayerScore(controller);
                ResetPosition(width / 2, 250);
            }
        }

        public void ResetPosition(int startX, int startY)
        {
            X = startX;
            Y = startY;
            SpeedX = 5;
            SpeedY = 5;
        }
    }
}
