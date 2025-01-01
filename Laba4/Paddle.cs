using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4
{
    public class Paddle : IObserver
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public PictureBox PictureBox { get; set; }
        public bool IsComputerControlled { get; set; } 

        public Paddle(int x, int y, int width, int height, bool isComputerControlled = false)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            IsComputerControlled = isComputerControlled;
        }

        public void Update(int ballY)
        {
            if (IsComputerControlled)
            {
                int paddleCenter = Y + Height / 2;

                if (ballY > paddleCenter)
                {
                    CheckPosition();
                    Y += 10; 
                }
                else if (ballY < paddleCenter)
                {
                    CheckPosition();
                    Y -= 10;
                }
            }
        }

        public void MoveUp()
        {
            CheckPosition();
            Y -= 15;
        }

        public void MoveDown()
        {
            CheckPosition();
            Y += 15;
            
        }

        public void CheckPosition()
        {
            if (Y < 20)
            {
                Y = 20;
            }
            else if (Y + Height > 470)
            {
                Y = 470 - Height;
            }
        }

        
    }
}
