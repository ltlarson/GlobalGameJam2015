using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum Controls
{
    nothing,
    left,
    right,
    special
}
public class Recorder : MonoBehaviour
{
    [HideInInspector]
    public List<Controls> recordedInput;

    Controls controls;

    public enum RecordingCharacter
    {
        None,
        ButtonPusher,
        StrongMan,
        JumpyFatty
    }

    public static RecordingCharacter recordingCharacter;
    Receiver receiver;
    void Start()
    {
        recordedInput = new List<Controls>();
        recordingCharacter = RecordingCharacter.None;
        if (GetComponent<Receiver>() != null)
        {
            receiver = GetComponent<Receiver>();
        }
    }

    void Update()
    {
        if (recordingCharacter != RecordingCharacter.None)
        {
            if (RecordingCharacterIsThis())
            {
                if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    recordedInput.Add(Controls.nothing);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    Debug.Log("Recording Input for " + this.name);
                    recordedInput.Add(Controls.right);
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    recordedInput.Add(Controls.left);
                }
                else if (Input.GetKey(KeyCode.Space))
                {
                    recordedInput.Add(Controls.special);
                }
                else
                {
                    recordedInput.Add(Controls.nothing);
                }
            }
            StreamToCharacter();
        }
    }

    public void CharacterSwitch()
    {
        if (RecordingCharacterIsThis())
        {
            Debug.Log("Switched to: " + recordingCharacter);
            recordedInput.Clear();
        }
        streamIndexer = 0;
    }

    bool RecordingCharacterIsThis()
    {
        if (recordingCharacter.ToString() == this.name)
        {
            return true;
        }
        return false;
    }

    [HideInInspector]
    public int streamIndexer;
    void StreamToCharacter()
    {
        if (receiver != null)
        {
            if (recordedInput.Count > 0 && streamIndexer <= recordedInput.Count - 1)
            {
                receiver.RecieveControl(recordedInput[streamIndexer]);
                streamIndexer++;
            }
        }
    }
}
