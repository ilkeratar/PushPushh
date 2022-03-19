using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void NextLevel(){
        SceneManager.LoadScene("Level"+ PlayerPrefs.GetInt("Level",2));
        PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level",2)+1);
    }
}
