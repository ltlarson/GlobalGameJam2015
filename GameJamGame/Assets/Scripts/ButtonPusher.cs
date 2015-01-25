using UnityEngine;
using System.Collections;

public class ButtonPusher : MonoBehaviour
{

    private bool onFloor = true;
    private int jumpCounter;
    private bool isJumping = false;
    private Vector3 Velocity;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /* Velocity = Vector3.zero;
         if (onFloor == true)
         {
             if (Input.GetKey(KeyCode.RightArrow) == true)
             {
                 transform.position -= Vector3.right * Time.deltaTime * 5f;
             }

             else if (Input.GetKey(KeyCode.LeftArrow) == true)
             {
                 transform.position += Vector3.right * Time.deltaTime * 5f;
             }

             transform.rigidbody.velocity = Velocity;

         }
         */

    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Button")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Button Pushed!");
            }

        }
    }
}
