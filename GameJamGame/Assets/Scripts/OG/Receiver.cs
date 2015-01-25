using UnityEngine;
using System.Collections;

public class Receiver : MonoBehaviour
{
    [HideInInspector]
    public Vector3 startPosition;
    public void Start()
    {
        startPosition = transform.position;
    }

    public float speed;
    public Controls currentControl;

    public void Update()
    {

    }

    public virtual void RecieveControl(Controls control)
    {
        if (control == Controls.left)
        {
            currentControl = Controls.left;
            transform.position += speed * transform.forward * -1 * Time.deltaTime;
        }
        else if (control == Controls.right)
        {
            currentControl = Controls.right;
            transform.position += speed * transform.forward * Time.deltaTime;
        }
        else if (control == Controls.special)
        {
            currentControl = Controls.special;
        }
        else if (control == Controls.nothing)
        {
            currentControl = Controls.nothing;
        }
        else
        {
            currentControl = Controls.nothing;
        }
    }
}
