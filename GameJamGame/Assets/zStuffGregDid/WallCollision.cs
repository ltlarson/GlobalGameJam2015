using UnityEngine;
using System.Collections;

public class WallCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
        start = transform.position.y;
	}
    float start;
    public static bool stopWall;
  //  public Animation animation;
  // public  Animator animator;
    //public GameObject wall;
	// Update is called once per frame
	void Update () {
        Debug.Log(Level1Button.triggering);
	}
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name=="Filing Cabinet"&&transform.position.y>start+1)
        {

            //make them husks of their former selves.
            Destroy(other.gameObject.rigidbody);
            Destroy(gameObject.rigidbody);
            Destroy(gameObject.collider);
            Destroy(other.gameObject.collider);
        }
        else
        {
            stopWall = false;
        }
    }

}
