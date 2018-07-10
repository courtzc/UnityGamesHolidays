using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Collectable : MonoBehaviour {

	private GameManager myManager;
    public GameObject collectable;

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
        Debug.Log("I'm collecting the collectable");

		myManager.numToCollect--;

		Destroy(collectable);
    }
}
