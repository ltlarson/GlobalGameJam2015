using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum CharacterSelected { Red,Green,Blue};
public class ActivePlayerSelected : MonoBehaviour {
    public Image Arrow;
    
    public CharacterSelected myCharacter;
	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        Arrow.GetComponent<Animator>().SetInteger("ControlInt", (int)myCharacter);
	}

    public void SetActive(CharacterSelected input)
    {
        myCharacter = input;
    }

}
