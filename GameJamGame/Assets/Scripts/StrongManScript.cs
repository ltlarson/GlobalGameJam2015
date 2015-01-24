using UnityEngine;
using System.Collections;

public class StrongManScript : MonoBehaviour {

    private bool onFloor = true;
    private float speed;

    private Vector3 Direction;
    // Use this for initialization
    void Start()
    {
        speed = 5f;
        transform.rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Direction = Vector3.zero;
            if (onFloor == true)
            {
                if (Input.GetKey(KeyCode.D) == true)
                {
                    Direction = Vector3.right;
                }

                else if (Input.GetKey(KeyCode.A) == true)
                {
                    Direction = Vector3.left;
                }
                transform.position += Direction * Time.deltaTime * speed;

            }
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Boulder")
        {

            GameObject boulder = col.gameObject;
            boulder.transform.rigidbody.isKinematic = false;
            boulder.transform.position += Direction * Time.deltaTime * speed;

        }
    }
}
