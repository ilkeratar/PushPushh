using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace Examples.State
{
    public class PlayerIdleState : IState
    {
        PlayerSM _playerSM;
        Animator _animator;
        
        public PlayerIdleState(PlayerSM playerSM,Animator animator)
        {
            _playerSM=playerSM;
            _animator=animator;
        }

        public void Enter()
        {
            Debug.Log("STATE CHANGE - Idle");
            _animator.SetBool("isRun",false);

            
        }

        public void Exit()
        {
            
        }

        void IState.FixedTick()
        {
            
        }

        void IState.Tick()
        {
            _playerSM.ChangeStateToRun();
        }
    }
}
