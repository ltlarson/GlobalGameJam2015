using UnityEngine;
using System.Collections;

public class FatGuy : MonoBehaviour
{
    private bool onFloor = true;
    private int jumpCounter;
    private bool isJumping = false;
    private Vector3 Velocity;
    // Use this for initialization
    void Start()
    {
        transform.rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpCounter > 0)
        {
            transform.rigidbody.AddForce(Vector3.up * 50);
            jumpCounter--;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                isJumping = true;
                jumpCounter = 4;
                onFloor = false;
            }
        
            
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Floor" && isJumping == true)
        {
            GameObject boulder = GameObject.FindGameObjectWithTag("Boulder");

            boulder.transform.rigidbody.isKinematic = false;
            boulder.transform.rigidbody.useGravity = true;
                        
            onFloor = true;
            isJumping = false;
        }

        if(col.gameObject.tag == "Boulder")
        {
            col.gameObject.transform.rigidbody.isKinematic = true;


        }
    }
}
