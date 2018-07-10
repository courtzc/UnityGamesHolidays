using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	[Header("Add every player in the scene to list")]
	public GameObject[] players;

	[Header("Add the camera in the scene here which follows the player")]
	public Camera myCamera;


	[Header("when using camera follow this variables set the bounds")]
	[Header("The smallest x(left/right) value the camera can go to")]
	public float cameraMinX = -10.0f;
	[Header("The largest x(left/right) value the camera can go to")]
	public float cameraMaxX = 10.0f;
	[Header("The smallest y (up/down) value the camera can go to")]
	public float cameraMinY = 1.0f;
	[Header("The largest y (up/down) value the camera can go to")]
	public float cameraMaxY = 10.0f;

	//variables around the player currently selected
	private Rigidbody2D currentSelectedPlayer;
	private PlayerSettings currentSelectedPlayerSettings;
	private int playerIndex = 0;

	private bool hasDoubleJumped = false;


	// Use this for initialization
	void Start () 
	{
		//initalise current player
		currentSelectedPlayer = players[playerIndex].GetComponent<Rigidbody2D>();
		currentSelectedPlayerSettings = players[playerIndex].GetComponent<PlayerSettings>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		//check for keypress to switch players
		if(Input.GetKeyDown(KeyCode.Z))
		{
			//switch player
			SwitchPlayer();
		}

		//make the camera follow the player
		CameraFollow();

	}
		

	void FixedUpdate()
	{
		//move the player
		MovePlayer();
	}

	void MovePlayer()
	{


		//detemine if player is moving left or right
		float horizontalForce = Input.GetAxis("Horizontal") * Time.deltaTime * 5000.0f * currentSelectedPlayerSettings.speed;

		//create variable to determine if jumping and assume you aren't
		float jump = 0.0f;
		//check if the player is touching the ground
		if(currentSelectedPlayerSettings.isGrounded || currentSelectedPlayerSettings.isWallGrounded)
		{
			//check if jump button is pressed
			if(Input.GetButtonDown("Jump"))
			{
				//determine jump height
				jump = Time.deltaTime * 50000.0f * currentSelectedPlayerSettings.jumpHeight;
				//play jump sound
				GetComponent<AudioSource>().Play();
				if(currentSelectedPlayerSettings.isGrounded)
					currentSelectedPlayerSettings.isGrounded = false;
				else
					currentSelectedPlayerSettings.isWallGrounded = false;
			}

			//reset double jump
			hasDoubleJumped = false;
		}
		else
		{
			//double jump
			/*
			if(!hasDoubleJumped)
			{
				if(Input.GetButtonDown("Jump"))
				{
					//determine jump height
					jump = Time.deltaTime * 50000.0f * currentSelectedPlayerSettings.jumpHeight;
					//play jump sound
					GetComponent<AudioSource>().Play();

					hasDoubleJumped = true;
				}
			}*/

		}

		//apply force to player
		currentSelectedPlayer.AddForce(new Vector2(horizontalForce,jump));

	}

	void SwitchPlayer()
	{

		//increase the player index
		playerIndex++;

		//check if the player index is greater than the number of players
		if(playerIndex >= players.Length)
		{
			//reset player index
			playerIndex = 0;
		}

		//initalise the new player
		currentSelectedPlayer = players[playerIndex].GetComponent<Rigidbody2D>();
		currentSelectedPlayerSettings = players[playerIndex].GetComponent<PlayerSettings>();
	}

	void CameraFollow()
	{
		//Make the main camera follow the player

		myCamera.transform.position = new Vector3(Mathf.Clamp(currentSelectedPlayer.transform.position.x, cameraMinX, cameraMaxX), 
			Mathf.Clamp(currentSelectedPlayer.transform.position.y, cameraMinY,cameraMaxY), myCamera.transform.position.z);
	}

}
