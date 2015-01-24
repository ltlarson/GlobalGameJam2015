using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Actions
{
    nothing,
    up,
    down,
    right,
    left,
    special,
    end
}

public class Recorder : MonoBehaviour
{
    List<Actions> actions;
    void Start()
    {
        startPosition = transform.position;
        actions = new List<Actions>();
        recording = false;
        playing = false;
        canChangeCharacter = true;
    }

    Vector3 startPosition;
    public static bool canChangeCharacter;
    void Update()
    {
        if (MasterController.character.ToString() == this.tag)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartRecord();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                StopRecord();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Play();
        }


        if (playing)
        {
            if (actionNumber + 1 != actions.Count && actions.Count > 0)
            {
                actionNumber++;
                SendAction();
            }
            else
            {
                playing = false;
                Debug.Log("Done Playing");
            }
        }
    }

    public static void SwitchedCharacter()
    {

    }

    [HideInInspector]
    public bool recording;
    void StartRecord()
    {
        if (!recording && !playing)
        {
            transform.position = startPosition;
            recording = true;
            actions.Clear();
            canChangeCharacter = false;
            Debug.Log("Recording");
        }
    }

    void StopRecord()
    {
        if (recording)
        {
            transform.position = startPosition;
            recording = false;
            actions.Add(Actions.end);
            canChangeCharacter = true;
            Debug.Log("Done Recording");
        }
    }

    [HideInInspector]
    public bool playing;
    void Play()
    {
        if (!recording && !playing)
        {
            Debug.Log("Playing");
            transform.position = startPosition;
            actionNumber = 0;
            playing = true;
            canChangeCharacter = false;
        }
        foreach (int action in actions)
        {
            Debug.Log(name + ": " + (Actions)action);
        }
    }

    int actionNumber;
    public int SendAction()
    {
        return (int)actions[actionNumber];
    }

    public void RecieveAction(int action)
    {
        if (recording)
        {
            actions.Add((Actions)action);
        }
        streamActionNumber = action;
    }

    int streamActionNumber;
    public int StreamReciever()
    {
        return streamActionNumber;
    }
}
