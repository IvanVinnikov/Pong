using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    public class Command : ICommand
    {
        private Paddle _paddle;
        private int _direction; 

        public Command(Paddle paddle, int direction)
        {
            _paddle = paddle;
            _direction = direction;
        }

        public void Execute()
        {
            if (_direction == 1)
            {
                _paddle.MoveDown();
            }
            else
            {
                _paddle.MoveUp();
            }
        }
    }

}
