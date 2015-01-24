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
            else if (onFloor == true)
            {
                if (Input.GetKey(KeyCode.RightArrow) == true)
                {
                    transform.position += Vector3.right * Time.deltaTime * 5f;
                }

                else if (Input.GetKey(KeyCode.LeftArrow) == true)
                {
                    transform.position += Vector3.left * Time.deltaTime * 5f;
                }

            }
            
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Floor" && isJumping == true)
        {
            GameObject[] boulders = GameObject.FindGameObjectsWithTag("Boulder");
            for(int i = 0; i<boulders.Length; i++)
            {
                if(boulders[i].name == "Boulder " + col.gameObject.name)
                {
                    boulders[i].transform.rigidbody.useGravity = true;
                    boulders[i].transform.rigidbody.isKinematic = false;
                }
            }
            onFloor = true;
            isJumping = false;
        }

        if(col.gameObject.tag == "Boulder")
        {
            col.gameObject.transform.rigidbody.isKinematic = true;
            Velocity = Vector3.zero;

        }
    }
}
