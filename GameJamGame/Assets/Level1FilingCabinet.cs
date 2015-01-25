using UnityEngine;
using System.Collections;

public class Level1FilingCabinet : MonoBehaviour
{
    Vector3 start;
    // Use this for initialization
    void Start()
    {
        start = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody != null && triggering)
        {
            rigidbody.useGravity = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = start;
            rigidbody.useGravity = false;
        }
    }

    bool triggering;
    public float jump;
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Beaux")
        {
            if (other.GetComponent<Receiver>().currentControl == Controls.special)
            {
                if (!triggering)
                {
                    other.rigidbody.AddForce(Vector3.up * jump);
                }
                triggering = true;
            }
        }
    }
}
