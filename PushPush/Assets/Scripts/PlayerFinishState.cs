using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Examples.State
{
    public class PlayerFinishState : IState
    {
        PlayerSM _playerSM;
        Animator _animator;
        Transform _transformPlayer;
        GameObject _gameui;
        GameObject _finishui;
        ParticleSystem _finishConf;
        ParticleSystem _finishConf1;

        public PlayerFinishState(PlayerSM playerSM,Animator animator,Transform transformPlayer,GameObject gameui,ParticleSystem finishConf,ParticleSystem finishConf1,GameObject finishui)
        {
            _playerSM=playerSM;
            _animator=animator;
            _transformPlayer=transformPlayer;
            _gameui=gameui;
            _finishConf=finishConf;
            _finishConf1=finishConf1;
            _finishui=finishui;
        }
        public void Enter()
        {
            Debug.Log("STATE CHANGE - Finish");
            _gameui.SetActive(false);
            _transformPlayer.GetChild(3).gameObject.SetActive(false);
            _transformPlayer.GetChild(6).gameObject.SetActive(true);
            _transformPlayer.Rotate(0,180f,0);
            _animator.SetBool("isFinish",true);
            _finishConf.Play();
            _finishConf1.Play();
            _finishui.SetActive(true);
        }

        public void Exit()
        {
            _animator.SetBool("isFinish",false);
        }

        public void FixedTick()
        {
            
        }

        public void Tick()
        {
            
        }
    }
}
