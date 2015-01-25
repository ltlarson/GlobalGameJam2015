using UnityEngine;
using System.Collections;

public class Level1Button : MonoBehaviour
{
    public GameObject door;
    float startY;
    Vector3 start;
    // Use this for initialization
    void Start()
    {
        startY = door.transform.position.y;
        start = transform.position;
    }

    // Update is called once per frame+
    void Update()
    {
        if (triggering)
        {
            if (door.transform.position.y < 3)
            {
                door.transform.position += Vector3.up * speed * Time.deltaTime;
            }
        }
        else
        {
            if (door.transform.position.y > startY)
            {
                door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(door.transform.position.x, startY, door.transform.position.z), .1f);
            }
            if (door.transform.position.y <= startY)
            {
                startY = door.transform.position.y;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = start;
        }
    }

    bool triggering;
    public float speed;
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Glenda")
        {
            if (other.GetComponent<Receiver>().currentControl == Controls.special)
            {
                triggering = true;
            }
            else
            {
                triggering = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Glenda")
        {
            triggering = false;
        }
    }
}
