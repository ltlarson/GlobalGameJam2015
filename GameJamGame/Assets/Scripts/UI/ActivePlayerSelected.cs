using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActivePlayerSelected : MonoBehaviour
{
    public Image Arrow;

    public static SelectedCharacter myCharacter;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Arrow.GetComponent<Animator>().SetInteger("ControlInt", (int)myCharacter);
    }

    public static void SetActive(SelectedCharacter input)
    {
        myCharacter = input;
    }

}
