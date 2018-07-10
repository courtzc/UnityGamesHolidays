using UnityEngine;
using System.Collections;

public class PlayerSettings : MonoBehaviour {




	[Header("Player Settings")]
	//speed multiplier of player
	[Header("Speed multiplier of player, 1.0 is a good starting point")]
	public float speed = 1.0f;
	//jump multiplier of player
	[Header("Jump multiplier of player, 1.0 is a good starting point")]
	public float jumpHeight = 1.0f;
	//should player wall jump?
	[Header("Should the player be able to jump off walls?")]
	public bool isWallJump = true;
    //sprites for player


    //Facing left
    [Header("Drag in your sprite of the player facing forward")]
    public Sprite standSprite;
    //Jump
    [Header("Drag in your sprite of the player in the air")]
    public Sprite jumpSprite;
    //hurt
    [Header("Drag in your hurt sprite")]
    public Sprite hurtSprite;



    //-------- vars below here changed by code-------
    //is the player grounded?
    [HideInInspector]
	public bool isGrounded = false;

	//is the player grounded?
	[HideInInspector]
	public bool isWallGrounded = false;

	//start position
	private Vector3 startPosition;

    // Use this for initialization
    void Start () 
	{
		//set start position
		startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if(isGrounded == false)
        {
            GetComponent<SpriteRenderer>().sprite = jumpSprite;
        }

        else
        {
            GetComponent<SpriteRenderer>().sprite = standSprite;
        }
    }

	//check for collisions
	void OnCollisionEnter2D(Collision2D coll) 
	{

		//if player collides with something called death
		if(coll.gameObject.tag == "Death")
		{
			//reset position
			transform.position = startPosition;
			//player hurt animation
			GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().sprite = hurtSprite;
		}
	}


}
