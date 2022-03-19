using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjects : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0,50*Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Wood"){
            other.transform.localScale+=new Vector3(0,0.1f,0);

            other.transform.localPosition =new Vector3(0,other.transform.localPosition.y,other.transform.localPosition.z);

            Destroy(gameObject);

        }
    }
}
