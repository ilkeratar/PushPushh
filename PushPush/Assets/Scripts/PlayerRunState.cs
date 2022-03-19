using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Examples.State
{
    public class PlayerRunState : IState
    {
        PlayerSM _playerSM;
        Rigidbody _rb;
        FloatingJoystick _joystick;
        Transform _transformPlayer;
        float _moveSpeed;
        Animator _animator;
        ParticleSystem _dustparticle;
        ParticleSystem _windparticle;
        int isRunningHash;

        public PlayerRunState(PlayerSM playerSM,float moveSpeed,Rigidbody rb,Animator animator,
        ParticleSystem dustparticle,ParticleSystem windparticle,FloatingJoystick joystick,Transform transformPlayer)
        {
            _playerSM=playerSM;
            _rb=rb;
            _joystick=joystick;
            _moveSpeed=moveSpeed;
            _animator=animator;
            _dustparticle=dustparticle;
            _windparticle=windparticle;
            _transformPlayer=transformPlayer;
        }

        public void Enter()
        {
            Debug.Log("STATE CHANGE - Run");
            isRunningHash=Animator.StringToHash("isRun");
            
        }
        public void Exit()
        {
            _animator.SetBool("isRun",false);
        }


        void IState.Tick()
        {
            
        }

       public void ChangeSpeed(float movespeed){
           _moveSpeed=movespeed;
       }
        void IState.FixedTick()
        {
            bool _isRunning = _animator.GetBool(isRunningHash);
            _rb.velocity=new Vector3(_joystick.Horizontal * _moveSpeed,_rb.velocity.y,_joystick.Vertical* _moveSpeed);

            if(_joystick.Horizontal!= 0 || _joystick.Vertical != 0)
            {
                if(!_isRunning)
                    _animator.SetBool("isRun",true);
                    
                _transformPlayer.rotation = Quaternion.LookRotation(_rb.velocity);
                } 
            else 
            {
                if(_isRunning)
                    _animator.SetBool("isRun",false);
            }
            
        }
    }
}

