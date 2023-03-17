using ExampleProject.UI;
using Sirenix.OdinInspector;
using System.Collections;
using VTLTools;
using UnityEngine;

namespace ExampleProject
{
    public class GameManager : Singleton<GameManager>
    {
        private GameState _state;
        [ShowInInspector]
        public GameState State
        {
            get => _state;
            set
            {
                _state = value;
                EventDispatcher.Instance.Dispatch(EventName.OnBeforeFightStateChange, _state);
                Debug.Log(State);
                switch (_state)
                {
                    case GameState.ResetRound:
                        HandleResetRound();
                        break;
                    case GameState.Starting:
                        HandleStartingState();
                        break;
                    case GameState.Idle:
                        HandleIdleState();
                        break;
                    case GameState.ChoosingNode:
                        HandleChoosingNodeState();
                        break;
                    case GameState.Run:
                        HandleRunState();
                        break;
                    case GameState.Fight:
                        HandleFightState();
                        break;
                    case GameState.AttackCastle:
                        HandleAttackCastle();
                        break;
                    case GameState.Lose:
                        HandleLose();
                        break;
                    case GameState.Win:
                        HandleWin();
                        break;
                    case GameState.Retry:
                        HandleRetry();
                        break;
                }
                EventDispatcher.Instance.Dispatch(EventName.OnAfterFightStateChange, _state);
            }
        }


        // Kick the game off with the first state
        void Start()
        {
            State = GameState.Starting;
        }

        void HandleResetRound()
        {
           
        }

      
        void HandleStartingState()
        {
            

        }
        void HandleIdleState()
        {
           
        }
        void HandleChoosingNodeState()
        {

        }
        void HandleRunState()
        {
            
        }
        void HandleFightState()
        {

        }

        void HandleAttackCastle()
        {

        }

        void HandleLose()
        {
           
        }
        void HandleWin()
        {
          
        }

        void HandleRetry()
        {
            

        }

        //aaaaaaaaaaaaaaaaaaaaaaaaa
    }
}