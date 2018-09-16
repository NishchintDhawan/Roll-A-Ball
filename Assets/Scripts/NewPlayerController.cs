using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewPlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private ConstantForce CF;
    public float speed;
    public float speed2;
    private int count;
    public Text count_text;
    public Text win_text;
    //public Vector3 force;

    private void Start()
    {
        count = 0;
        SetCountText();
        win_text.text = "";
        rb = GetComponent<Rigidbody>();
        CF = GetComponent<ConstantForce>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
       
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Gravity"))
        {
            //Vector3  = new Vector3(0.0f, -1, 0.0f);
            // CF.force = ;
            //Debug.Log("objectishit");
            rb.useGravity = false;
        }
    }


    private void SetCountText()
    {
        count_text.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            win_text.text = "You Win!";
        }
    }
}

