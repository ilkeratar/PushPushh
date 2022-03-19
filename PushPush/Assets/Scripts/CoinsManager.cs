using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] Text coinTxt;
    private int _c;
    private void Start() {
        _c=PlayerPrefs.GetInt("Coin");
        coinTxt.text=_c.ToString();
    }
    
    public int Coins{
        get{return _c;}
        set{
            _c=value;
            coinTxt.text=Coins.ToString();
        }
    }

    public void AddCoins(int amount){
        Coins+=amount;
        PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")+5);
    }
}
