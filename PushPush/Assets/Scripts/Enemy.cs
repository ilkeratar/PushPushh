using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float attackRange;
    [SerializeField] float movementSpeed;
    Rigidbody rb;
    public Animator enemyAnimator;
    float distance;
    GameObject player;
    Vector3 temp;
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        rb=transform.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        temp = player.transform.position;
        temp.y=transform.position.y;
        distance=Vector3.Distance(gameObject.transform.position,player.transform.position);
        if(distance<=attackRange)
        {
            transform.LookAt(player.transform);
            transform.Translate(Vector3.forward*movementSpeed*Time.deltaTime);
            enemyAnimator.SetBool("WALK",true);
        } 
    }
    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag=="Plane"){
            Destroy(gameObject);
        }

        if(other.transform.tag=="Wood"){
        Vector3 forceDirection = other.gameObject.transform.position - transform.position;
        forceDirection.y=0;
        forceDirection.Normalize();

        transform.GetComponent<Rigidbody>().AddForceAtPosition(-forceDirection* 2f,transform.position,ForceMode.Impulse);
        }
    }
        
}
