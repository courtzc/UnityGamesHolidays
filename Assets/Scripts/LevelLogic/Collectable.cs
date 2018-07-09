using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	private GameManager myManager;

	// Use this for initialization
	void Start () 
	{
		myManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//if something enters the collectable
	void OnTriggerEnter2D(Collider2D coll) 
	{
		
		GameObject.Find("CollectSound").GetComponent<AudioSource>().Play();
		myManager.numToCollect--;

		Destroy(gameObject);



	}

}
