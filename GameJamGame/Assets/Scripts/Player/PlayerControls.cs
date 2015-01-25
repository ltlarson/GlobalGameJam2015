using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{

    Recorder recording;
    void Start()
    {
        recording = GetComponent<Recorder>();
    }

    bool charChanged;
    void Update()
    {
        if (MasterController.character.ToString() == this.tag)
        {
            charChanged = false;
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                recording.RecieveAction((int)Actions.nothing);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                recording.RecieveAction((int)Actions.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                recording.RecieveAction((int)Actions.right);
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                recording.RecieveAction((int)Actions.special);
            }
            else
            {
                recording.RecieveAction((int)Actions.nothing);
            }
        }
        else
        {
            if (!charChanged)
            {
                recording.RecieveAction((int)Actions.end);
                charChanged = true;
            }
        }
    }
}
