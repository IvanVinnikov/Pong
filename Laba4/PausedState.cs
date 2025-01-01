using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    public class PausedState : IGameState
    {
        public void EnterState(GameController controller)
        {
            controller.StopTimer(); 
            controller.ShowPausedMessage(); 
        }

        public void ExitState(GameController controller)
        {
            controller.HidePausedMessage(); 
        }

        public void Update(GameController controller)
        {
            
        }
    }
}
