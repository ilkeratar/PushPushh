using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Examples.State
{
    public class PlayerSM : StateMachineMB 
    {
        [SerializeField] Animator _animator;
        [SerializeField] float _moveSpeed = 6;
        [SerializeField] Rigidbody _rb;
        [SerializeField] private ParticleSystem _dustparticle;
        [SerializeField] CinemachineVirtualCamera cam1;
        [SerializeField] private ParticleSystem _windparticle;
        [SerializeField] private ParticleSystem _finishConf;
        [SerializeField] private ParticleSystem _finishConf1;
        [SerializeField] private FloatingJoystick _joystick;
        [SerializeField] private Transform _transformPlayer;
        [SerializeField] GameObject _homeui;
        [SerializeField] GameObject _gameui;
        [SerializeField] GameObject _finishui;
        [SerializeField] GameObject _deadui;
        public PlayerIdleState IdleState{get; private set;}
        public PlayerRunState RunState{get; private set;}
        public PlayerFinishState FinishState{get; private set;}
        private void Awake() {
            IdleState = new PlayerIdleState(this,_animator);
            RunState = new PlayerRunState(this,_moveSpeed,_rb,_animator,_dustparticle,_windparticle,_joystick,_transformPlayer);
            FinishState=new PlayerFinishState(this,_animator,_transformPlayer,_gameui,_finishConf,_finishConf1,_finishui);
        }

        private void Start() {
            ChangeState(IdleState);
        }
        public void ChangeStateToRun(){
            if(Input.GetMouseButtonDown(0)){
            ChangeState(RunState);
            _homeui.SetActive(false);
            _gameui.transform.GetChild(1).transform.gameObject.SetActive(true);
            _gameui.transform.GetChild(2).transform.gameObject.SetActive(true);
            }  
        }
        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.tag=="FBoost")
                StartCoroutine(SpeedBoost());

            if(other.gameObject.tag=="Finish"){
                ChangeState(FinishState);
            }
            if(other.gameObject.tag=="Block")
            {
                ChangeState(IdleState);
                transform.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.None;
            }
            if(other.gameObject.tag=="Plane")
            {
                _gameui.gameObject.SetActive(false);
                _deadui.gameObject.SetActive(true);
            }
        }
        public void TryAgain()
        {
            SceneManager.LoadScene("Level"+(PlayerPrefs.GetInt("Level",2)-1));
            PlayerPrefs.SetInt("Coin",0);
        }
        public void PlayAgain()
        {
            SceneManager.LoadScene("Level1");
            PlayerPrefs.SetInt("Level",2);
            PlayerPrefs.SetInt("Coin",0);
        }
        

        IEnumerator SpeedBoost()
    {
        RunState.ChangeSpeed(10f);
        _dustparticle.Play();
        _windparticle.Play();
        yield return new  WaitForSeconds(2f);
        _windparticle.Stop();
        _dustparticle.Stop();
        RunState.ChangeSpeed(6f);
    }

    }
}
