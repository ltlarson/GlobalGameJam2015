using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{

    public float startY;
    public float endY;
    public float speed;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!doingThing)
        {
            if (transform.position.y > startY)
                transform.position += transform.up * -1 * Time.deltaTime * speed;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.position = startPos;
        }
    }

    public void DoThing()
    {
        doingThing = true;
        if (transform.position.y < endY)
            transform.position += transform.up * Time.deltaTime * speed;
    }

    bool doingThing;
    public void StopThing()
    {
        doingThing = false;
    }
}
