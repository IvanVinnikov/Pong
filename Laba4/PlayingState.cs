using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    public class PlayingState : IGameState
    {
        public void EnterState(GameController controller)
        {
            controller.StartTimer();
        }

        public void ExitState(GameController controller)
        {
            controller.StopTimer();
        }

        public void Update(GameController controller)
        {
            controller.UpdateGame();
        }
    }

}
