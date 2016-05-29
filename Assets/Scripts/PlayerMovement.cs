//SomeNerdNamedSteve
//PlayerMovement.cs
//The object of this script is to show how the player moves about
//a scene

//library imports
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


//beginning of class for player movement
public class PlayerMovement : MonoBehaviour {

    //text objects that will be used and manipulated in the game
    public Text scoreText, winText;

    //this will get the big object collectable
    public GameObject bigObject;

    //this holds the player start position and restart position
    public GameObject startPosition;

    //rigidbody variable taken from player
    public Rigidbody rb;

    //this denotes the speed for player movement
    private float speed = 0.05f;

    //this will hold the score of the player
    private int score;

    //this variable will hold my ability to jump
    private bool ableToJump;

	// Use this for initialization
	void Start () {

        //the score starts out as zero
        score = 0;

        //on game startup, the player can not see the win text
        winText.enabled = false;

        bigObject.active = false;

        scoreText.text = "Score: " + score;

        //this line gets the rigidbody given from the unity editor
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        //if the player's y coordinate is less than -10
        //bring the player to the start
        if (transform.position.y < -10) {
            transform.position = startPosition.transform.position;
        }

        //this region shows movement using wasd
        #region WASD
        //if w is pressed, the player moves forward
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(speed * Vector3.forward);
        }

        //if s is pressed, the player moves back
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(speed * Vector3.back);
        }

        //if a is pressed, the player moves left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(speed * Vector3.left);
        }

        //if d is pressed, the player moves right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Vector3.right);
        }
        #endregion

        //this region shows jumping for the player
        #region jump
        //if pressing the space bar, jump
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (ableToJump == true) {
                rb.AddForce(Vector3.up * 350);
            }
        }
        #endregion

    }

    //will be called once the player hits a trigger based
    //game object
    void OnTriggerEnter(Collider c)
    {
       
        //if we colelct a small collectable, get rid of it and increment
        //score by 1
        if (c.gameObject.tag.Equals("Small Collectable")) {
            Destroy(c.gameObject);
            score++;

            scoreText.text = "Score: " + score;

            //if the score is 6, then we can collect the Big Object
            if (score > 5)
            {
                bigObject.active = true;
                scoreText.text = "Go get the big object!";
            }
        }

        //if we collect the big object, the player wins
        if (c.gameObject.tag.Equals("Big Object")) {
            Destroy(c.gameObject);
            winText.enabled = true;
        }
    }

    //when the player collides with a non-trigger game object
    void OnCollisionEnter(Collision c) {
        //if player hits the ground, the player is able to jump
        if (c.gameObject.tag.Equals("Ground")) {
            ableToJump = true;
        }
    }

    //when the player exits a collision
    void OnCollisionExit(Collision c)
    {
        //if player jumps from the ground, the player is not able to jump
        if (c.gameObject.tag.Equals("Ground")){
            ableToJump = false;
        }
    }

}
//end class