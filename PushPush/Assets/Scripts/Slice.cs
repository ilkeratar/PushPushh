using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour
{
   Material mat;
   

   public void Cut(Transform cutter)
    {
        mat=GetComponent<MeshRenderer>().material;
        if (cutter.transform.position.x<0)
        {
            float y = transform.localScale.y;
            y -= transform.GetComponentInParent<Transform>().position.x;
            float dist = y + cutter.position.x;
            Debug.Log("dist 1 : " + dist);

            if(dist >transform.localScale.y)
            {
                float a = transform.localScale.y;
                a += transform.position.x;
                float dist1 = a - cutter.position.x;
                Debug.Log("dist 1.1 : " + dist1);

                if (dist1/2>0)
                {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - dist1 / 2, transform.localScale.z);
                transform.position = new Vector3(transform.position.x - dist1 / 2, transform.position.y, transform.position.z);

                GameObject yeni = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                yeni.transform.localScale = new Vector3(transform.localScale.x, dist1 / 2, transform.localScale.z);
                yeni.transform.rotation = transform.rotation;
                yeni.transform.position = new Vector3(a - yeni.transform.localScale.y, transform.position.y, transform.position.z);

                yeni.AddComponent<Rigidbody>();
                yeni.GetComponent<Renderer>().material=mat;
                StartCoroutine(DestroyWood(yeni));
                }
            }
            else
            {
                if (dist/2>0)
                {

                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - dist / 2, transform.localScale.z);
                transform.position = new Vector3(transform.position.x + dist / 2, transform.position.y, transform.position.z);

                GameObject yeni = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                yeni.transform.localScale = new Vector3(transform.localScale.x, dist / 2, transform.localScale.z);
                yeni.transform.rotation = transform.rotation;
                yeni.transform.position = new Vector3(-(y - yeni.transform.localScale.y), transform.position.y, transform.position.z);

                yeni.AddComponent<Rigidbody>();
                yeni.GetComponent<Renderer>().material=mat;
                StartCoroutine(DestroyWood(yeni));

                }
            }
            
            

        }
        else
        {
            float y = transform.localScale.y;
            y += transform.position.x;
            float dist = y - cutter.position.x;
            Debug.Log("dist 2 : " + dist);

            if(dist >transform.localScale.y)
            {
                float a = transform.localScale.y;
                a -= transform.position.x;
                float dist1 = a + cutter.position.x;
                Debug.Log("dist 2.1 : " + dist1);

                if (dist1/2>0)
                {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - dist1 / 2, transform.localScale.z);
                transform.position = new Vector3(transform.position.x + dist1 / 2, transform.position.y, transform.position.z);

                GameObject yeni = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                yeni.transform.localScale = new Vector3(transform.localScale.x, dist1 / 2, transform.localScale.z);
                yeni.transform.rotation = transform.rotation;
                yeni.transform.position = new Vector3(-(a - yeni.transform.localScale.y), transform.position.y, transform.position.z);

                yeni.AddComponent<Rigidbody>();
                yeni.GetComponent<Renderer>().material=mat;
                StartCoroutine(DestroyWood(yeni));
                }
            }
            else
            {
                if (dist/2>0)
                {

                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - dist / 2, transform.localScale.z);
                transform.position = new Vector3(transform.position.x - dist / 2, transform.position.y, transform.position.z);

                GameObject yeni = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                yeni.transform.localScale = new Vector3(transform.localScale.x, dist / 2, transform.localScale.z);
                yeni.transform.rotation = transform.rotation;
                yeni.transform.position = new Vector3(y - yeni.transform.localScale.y, transform.position.y, transform.position.z);

                yeni.AddComponent<Rigidbody>();
                yeni.GetComponent<Renderer>().material=mat;
                StartCoroutine(DestroyWood(yeni));
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Saw")
        {
            Cut(other.gameObject.transform);
        }
    }

    IEnumerator DestroyWood(GameObject wood){
        yield return new WaitForSeconds(.4f);
        Destroy(wood);
    }

}
