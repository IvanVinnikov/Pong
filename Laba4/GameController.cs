using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Laba4
{
    public class GameController
    {
        public GameState _state;
        public GameView _view;
        public Timer _timer;
        private IGameState _currentState;

        private readonly IGameState _playingState;
        private readonly IGameState _pausedState;

        private bool _gameOverDisplayed = false; 
        private Dictionary<Keys, ICommand> _commands; 

        public GameController(GameState state, GameView view)
        {
            _state = state;
            _view = view;
            _timer = new Timer { Interval = 20 };
            _timer.Tick += (s, e) => UpdateGame();

            _commands = new Dictionary<Keys, ICommand>
            {
                { Keys.Up, new Command(_state.PlayerPaddle, -1) },
                { Keys.Down, new Command(_state.PlayerPaddle, 1) },
                { Keys.W, new Command(_state.PlayerPaddle, -1) },
                { Keys.S, new Command(_state.PlayerPaddle, 1) }
            };
            _playingState = new PlayingState();
            _pausedState = new PausedState();

            SetState(_playingState);

            _view.KeyDown += OnKeyDown;
        }


        public void SetState(IGameState newState)
        {
            _currentState?.ExitState(this); 
            _currentState = newState;     
            _currentState.EnterState(this); 
        }

        public void StartTimer()
        {
            _timer.Start();
        }

        public void StopTimer()
        {
            _timer.Stop();
        }


        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (_commands.ContainsKey(e.KeyCode))
            {
                _commands[e.KeyCode].Execute(); 
            }

            if (e.KeyCode == Keys.Space)
            {
                if (_currentState is PlayingState)
                {
                    SetState(_pausedState);
                }
                else if (_currentState is PausedState)
                {
                    SetState(_playingState);
                }
            }

            if (_currentState is PlayingState)
            {
                if (e.KeyCode == Keys.Up)
                {
                    _state.PlayerPaddle.MoveUp();
                }
                else if (e.KeyCode == Keys.Down)
                {
                    _state.PlayerPaddle.MoveDown();
                }
            }
        }

        public void UpdateGame()
        {
            if (!_gameOverDisplayed) 
            {
                HandleComputerPaddleSubscription();
                _state.Ball.HandleWallCollision(500);
                _state.Ball.CheckSideCollision(800, _state.Score, this);
                _state.Ball.HandlePaddleCollision(_state.PlayerPaddle, _state.ComputerPaddle);
                _state.Ball.Move();
                _view.UpdateView();
            }
        }

        private void HandleComputerPaddleSubscription()
        {
            if (_state.Ball.X > 400 && !_state.ComputerPaddleSubscribed)
            {
                _state.Ball.Attach(_state.ComputerPaddle);
                _state.ComputerPaddleSubscribed = true;
            }
            if (_state.Ball.X <= 400 && _state.ComputerPaddleSubscribed)
            {
                _state.Ball.Detach(_state.ComputerPaddle); 
                _state.ComputerPaddleSubscribed = false;
            }
        }

        public void ShowRestartMenu()
        {
            if (!_gameOverDisplayed) 
            {
                _gameOverDisplayed = true; 
                _timer.Stop(); 

                DialogResult result = MessageBox.Show(
                    "Game Over!\nWould you like to restart?",
                    "Game Over",
                    MessageBoxButtons.YesNo
                );

                if (result == DialogResult.Yes)
                {
                    RestartGame();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        public void RestartGame()
        {
            _gameOverDisplayed = false; 
            _state.Score.Reset();
            _state.Score.UpdateFormTitle(this);
            _state.Ball.ResetPosition(_view.Width / 2, _view.Height / 2);
            _state.PlayerPaddle.Y = (_view.Height - _state.PlayerPaddle.Height) / 2;
            _state.ComputerPaddle.Y = (_view.Height - _state.ComputerPaddle.Height) / 2;

            _view.UpdateView();

            _timer.Start();
        }
        public void ShowPausedMessage()
        {
            _view.Text = "Game Paused - Press Space to Resume";
        }

        public void HidePausedMessage()
        {
            _view.Text = $"Player {_state.Score._playerScore} | Computer {_state.Score._computerScore}";
        }
    }
}
