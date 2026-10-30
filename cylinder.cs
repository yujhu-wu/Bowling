using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cylinder : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool fallen = false;

    public Text countText;
    public Text winText;

    private static int count;
    private Rigidbody rb;

    void Start ()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        count = 0;
        SetCountText();
        winText.text = "";
        fallen = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            ResetGame();
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            HalfResetGame();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("cylinder") && collision.relativeVelocity.magnitude > 0.1f)
        {
            if (!fallen){
                count = count + 1;
                SetCountText();
                fallen = true;
            }
        }
    }

    void ResetGame()
    {
        fallen = false;
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        count = 0;
        SetCountText();
        winText.text = "";
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void HalfResetGame()
    {
        GameObject[] cylinders = GameObject.FindGameObjectsWithTag("cylinder");
        foreach (GameObject cylinder in cylinders) {
            if (cylinder.GetComponent<cylinder>().fallen) {
                cylinder.SetActive(false);
            }
        }
    }
    void SetCountText()
    {
        countText.text = "碰倒球數: " + count.ToString ();
        if (count >= 10){
            winText.text = "Strike!";
        }
    }
}
