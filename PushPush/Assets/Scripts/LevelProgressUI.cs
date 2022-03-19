using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
    [SerializeField] private Image uiFillImage;
    [SerializeField] private Text uiStartText;
    [SerializeField] private Text uiEndText;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform endLineTransform;

    private Vector3 endLinePosition;
    private float fullDistance;
    private void Start() {
        endLinePosition=endLineTransform.position;
        fullDistance=GetDistance();
    }
    public void SetLevelTexts(int level){
        uiStartText.text=level.ToString();
        uiEndText.text=(level+1).ToString();
    }
    
    private float GetDistance(){
        Vector3 playerPos = playerTransform.position;
	    playerPos.x = 0; //lock x axis
	    return (endLinePosition - playerPos).sqrMagnitude ;
    }

    private void UpdateProgressFill(float value){
        uiFillImage.fillAmount=value;
    }

    private void Update(){
        if(playerTransform.position.z<=endLinePosition.z){
            float newDistance=GetDistance();
            float progressValue=Mathf.InverseLerp(fullDistance,0f,newDistance);
            UpdateProgressFill(progressValue);
        } 
    }
}
