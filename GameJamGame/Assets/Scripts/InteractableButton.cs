using UnityEngine;
using System.Collections;

public class InteractableButton : MonoBehaviour
{
    public GameObject buttonRecipient;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Glenda")
        {
            if (other.gameObject.GetComponent<PlayerMovement>().action == Actions.special)
            {
                Debug.Log("doing special");
                if (buttonRecipient.name == "Wall")
                {
                    buttonRecipient.GetComponent<Wall>().DoThing();
                }
                else if (buttonRecipient.name == "toggle")
                {
                    // buttonRecipient.GetComponent<Wall>().DoThing();
                }
            }
            else if (other.gameObject.GetComponent<PlayerMovement>().action == Actions.end || other.gameObject.GetComponent<PlayerMovement>().action == Actions.nothing)
            {
                Debug.Log("doing nothing");
                if (buttonRecipient.name == "Wall")
                {
                    buttonRecipient.GetComponent<Wall>().StopThing();
                }
                else if (buttonRecipient.name == "toggle")
                {
                    // buttonRecipient.GetComponent<Wall>().DoThing();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (buttonRecipient.name == "Wall")
        {
            buttonRecipient.GetComponent<Wall>().StopThing();
        }
    }
}
