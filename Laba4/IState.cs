using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    public interface IGameState
    {
        void EnterState(GameController controller);
        void ExitState(GameController controller);
        void Update(GameController controller);
    }

}
