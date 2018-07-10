using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour
{

    //the target is the player that should use this portal
    [Header("Drag the player who trying to get to this portal into it")]
    public GameObject target;
    //is the target in the portal?
    [HideInInspector]
    public bool isTarget = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //if something enters the portal
    void OnTriggerEnter2D(Collider2D coll)
    {
        //check if object that has entered is the target
        if (coll.gameObject == target)
        {
            //set isTarget to true
            isTarget = true;
            //play a sound
            GetComponent<AudioSource>().Play();

        }
        //myPlayerSettings.isGrounded = true;

    }
    //if something exits portal
    void OnTriggerExit2D(Collider2D coll)
    {
        //check that the object that has exited is the target
        if (coll.gameObject == target)
        {
            //set isTarget to false
            isTarget = false;
        }

    }
}
