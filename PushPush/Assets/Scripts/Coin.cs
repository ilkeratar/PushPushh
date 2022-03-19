using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    CoinsManager coinsManager;
    private void Start() {
        coinsManager=FindObjectOfType<CoinsManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Wood"){
            coinsManager.AddCoins(5);
            Destroy(transform.parent.transform.parent.gameObject);
        }
    }
}
