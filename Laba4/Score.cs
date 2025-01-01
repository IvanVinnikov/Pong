using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4
{
    public class Score
    {
        public int _playerScore;
        public int _computerScore;

        public Score()
        {
            Reset();
        }

        public void IncrementPlayerScore(GameController controller)
        {
            _playerScore++;
            UpdateFormTitle(controller);
            CheckForWin(controller);
        }

        public void IncrementComputerScore(GameController controller)
        {
            _computerScore++;
            UpdateFormTitle(controller);
            CheckForWin(controller);
        }

        public void Reset()
        {
            _playerScore = 0;
            _computerScore = 0;
        }

        public void UpdateFormTitle(GameController controller)
        {
            controller._view.Text = $"Player - {_playerScore} | Computer - {_computerScore}";
        }

        private void CheckForWin(GameController controller)
        {
            if (_playerScore >= 5 || _computerScore >= 5)
            {
                controller._timer.Stop(); 
                controller.ShowRestartMenu(); 
            }
        }

    }

}
