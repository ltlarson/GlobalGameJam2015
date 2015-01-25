using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum SelectedCharacter
{
    JumpyFatty,
    ButtonPusher,
    StrongMan

}
public class CharacterSelect : MonoBehaviour
{
    public List<GameObject> characters;
    void CharacterSwitch()
    {
        foreach (GameObject character in characters)
        {
            if (Recorder.recordingCharacter.ToString() == character.name)
            {
                character.GetComponent<Recorder>().recordedInput.Clear();
                ActivePlayerSelected.SetActive((SelectedCharacter)Recorder.recordingCharacter - 1);
            }
            character.GetComponent<Recorder>().streamIndexer = 0;
            character.transform.position = character.GetComponent<Receiver>().startPosition;
        }
    }

    // Use this for initialization
    void Start()
    {
        selectedCharacter = SelectedCharacter.ButtonPusher;
        characterSelected = false;
        ActivePlayerSelected.SetActive(selectedCharacter);
    }

    public static SelectedCharacter selectedCharacter;
    public static bool characterSelected;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (GameObject character in characters)
            {
                character.GetComponent<Recorder>().recordedInput.Clear();
                Recorder.recordingCharacter = Recorder.RecordingCharacter.None;
                character.GetComponent<Recorder>().streamIndexer = 0;
                Debug.Log("Restart");
                character.transform.position = character.GetComponent<Receiver>().startPosition;
            }
            CharacterSelect.characterSelected = false;
        }

        if (!characterSelected)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (selectedCharacter == SelectedCharacter.ButtonPusher)
                {
                    selectedCharacter = SelectedCharacter.JumpyFatty;
                }
                else if (selectedCharacter == SelectedCharacter.StrongMan)
                {
                    selectedCharacter = SelectedCharacter.ButtonPusher;
                }
                else if (selectedCharacter == SelectedCharacter.JumpyFatty)
                {
                    selectedCharacter = SelectedCharacter.StrongMan;
                }
                Debug.Log("Selecting: " + selectedCharacter);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (selectedCharacter == SelectedCharacter.ButtonPusher)
                {
                    selectedCharacter = SelectedCharacter.StrongMan;
                }
                else if (selectedCharacter == SelectedCharacter.StrongMan)
                {
                    selectedCharacter = SelectedCharacter.JumpyFatty;
                }
                else if (selectedCharacter == SelectedCharacter.JumpyFatty)
                {
                    selectedCharacter = SelectedCharacter.ButtonPusher;
                }
                Debug.Log("Selecting: " + selectedCharacter);
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                Recorder.recordingCharacter = (Recorder.RecordingCharacter)selectedCharacter + 1;
                characterSelected = true;
                Debug.Log("Selected: " + selectedCharacter);
            }
            ActivePlayerSelected.SetActive(selectedCharacter);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (Recorder.recordingCharacter == Recorder.RecordingCharacter.ButtonPusher)
                {
                    Recorder.recordingCharacter = Recorder.RecordingCharacter.JumpyFatty;
                }
                else if (Recorder.recordingCharacter == Recorder.RecordingCharacter.StrongMan)
                {
                    Recorder.recordingCharacter = Recorder.RecordingCharacter.ButtonPusher;
                }
                else if (Recorder.recordingCharacter == Recorder.RecordingCharacter.JumpyFatty)
                {
                    Recorder.recordingCharacter = Recorder.RecordingCharacter.StrongMan;
                }
                CharacterSwitch();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (Recorder.recordingCharacter == Recorder.RecordingCharacter.ButtonPusher)
                {
                    Recorder.recordingCharacter = Recorder.RecordingCharacter.StrongMan;
                }
                else if (Recorder.recordingCharacter == Recorder.RecordingCharacter.StrongMan)
                {
                    Recorder.recordingCharacter = Recorder.RecordingCharacter.JumpyFatty;
                }
                else if (Recorder.recordingCharacter == Recorder.RecordingCharacter.JumpyFatty)
                {
                    Recorder.recordingCharacter = Recorder.RecordingCharacter.ButtonPusher;
                }
                CharacterSwitch();
            }
        }
    }
}
