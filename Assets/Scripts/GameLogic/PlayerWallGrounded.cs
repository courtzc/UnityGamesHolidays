using UnityEngine;
using System.Collections;

public class PlayerWallGrounded : MonoBehaviour {

	//get the players settings
	public PlayerSettings myPlayerSettings;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll) 
	{
		//set player grounded
		if(myPlayerSettings.isWallJump)
			myPlayerSettings.isWallGrounded = true;

	}
	void OnTriggerExit2D(Collider2D coll) 
	{
		//set player not grounded
		myPlayerSettings.isWallGrounded = false;

	}
	void OnTriggerStay2D(Collider2D coll) 
	{
		//set player grounded
		if(myPlayerSettings.isGrounded && myPlayerSettings.isWallJump)
			myPlayerSettings.isWallGrounded = true;
	}
}
