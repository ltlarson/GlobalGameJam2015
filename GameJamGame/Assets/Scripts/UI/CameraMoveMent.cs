using UnityEngine;
using System.Collections;

public class CameraMoveMent: MonoBehaviour {
    bool gameStarted = false;
    public GameObject animator;
	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(!gameStarted)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                gameStarted = true;
                animator.GetComponent<Animator>().SetBool("GameStart", true);
                Debug.Log("Animation should be playing");
            }
        }
	}
}
