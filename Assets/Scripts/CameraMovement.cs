//SomeNerdNamedSteve
//CameraMovement.cs
//this script will allow for the camera to trace behind the player

//library imports
using UnityEngine;
using System.Collections;


//beginning of class
public class CameraMovement : MonoBehaviour {

    //this will be the game object we are tracking
    public GameObject player;

    //gets camera displacement from player
    private Vector3 displacement;

	// Use this for initialization
	void Start () {
        //create the displacement vector with respect to the player
        displacement = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
    // LateUpdate is called when physics engine is needed
	void LateUpdate () {
        //this will track movement and replace the camera when needed
        transform.position = player.transform.position + displacement;
	}

}
//end class