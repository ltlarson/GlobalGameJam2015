using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        MasterController.character = MasterController.Characters.Glenda;
    }

    // Update is called once per frame
    void Update()
    {
        if (Recorder.canChangeCharacter)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                //NOTHING
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow)) //TOP: BEAUX, MIDDLE: GLENDA, BOTTOM: DEREK
            {
                Debug.Log("Up");
                if (MasterController.character == MasterController.Characters.Glenda)
                {
                    MasterController.character = MasterController.Characters.Beaux;
                }
                else if (MasterController.character == MasterController.Characters.Beaux)
                {
                    MasterController.character = MasterController.Characters.Derek;
                }
                else if (MasterController.character == MasterController.Characters.Derek)
                {
                    MasterController.character = MasterController.Characters.Glenda;
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Down");
                if (MasterController.character == MasterController.Characters.Glenda)
                {
                    MasterController.character = MasterController.Characters.Derek;
                }
                else if (MasterController.character == MasterController.Characters.Beaux)
                {
                    MasterController.character = MasterController.Characters.Glenda;
                }
                else if (MasterController.character == MasterController.Characters.Derek)
                {
                    MasterController.character = MasterController.Characters.Beaux;
                }
            }
        }
    }
}
