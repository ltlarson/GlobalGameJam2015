using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{

    Recorder recording;
    void Start()
    {
        recording = GetComponent<Recorder>();
    }

    public Actions action;
    public float speed;
    void Update()
    {
        action = (Actions)recording.StreamReciever();
        if (recording.playing)
            action = (Actions)recording.SendAction();
        switch (action)
        {
            case Actions.nothing:
                break;
            case Actions.up:
                break;
            case Actions.down:
                break;
            case Actions.left:
                transform.position += transform.right * -1 * Time.deltaTime * speed;
                break;
            case Actions.right:
                transform.position += transform.right * Time.deltaTime * speed;
                break;
            case Actions.special:
                break;
            case Actions.end:
                break;
        }
    }
}
