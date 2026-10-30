using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invicibleWall : MonoBehaviour
{

    void Start ()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag ("Player"))
        {
             //playerObject = other.gameObject;
             other.gameObject.transform.position= new Vector3((float)0,(float)0.5,(float)0);// 位置(0, 0.5, 0)
             Rigidbody rb= other.gameObject.GetComponent<Rigidbody>(); //取得剛體
             rb.velocity = Vector3.zero;//移動速度 =0
             rb.angularVelocity = Vector3.zero;//旋轉速度 =0

        }
    }

}
