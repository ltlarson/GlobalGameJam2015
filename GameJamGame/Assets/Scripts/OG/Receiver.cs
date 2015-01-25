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
    public virtual void RecieveControl(Controls control)
    {
        Debug.Log(this.name + " recieved " + control + " control");
        if (control == Controls.left)
        {
            transform.position += speed * transform.right * -1 * Time.deltaTime;
        }
        else if (control == Controls.right)
        {
            transform.position += speed * transform.right * Time.deltaTime;
        }
        else if (control == Controls.special)
        {

        }
        else if (control == Controls.nothing)
        {

        }
        else
        {

        }
    }
}
