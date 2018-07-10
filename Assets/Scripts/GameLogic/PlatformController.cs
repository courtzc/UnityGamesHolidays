using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Header("The farthest left the platform can move")]
    public float distanceLeft;
    [Header("The farthest right the platform can move")]
    public float distanceRight;
    [Header("The farthest up the platform can move")]
    public float distanceUp;
    [Header("The farthest down the platform can move")]
    public float distanceDown;


    public void Start()
    {

    }

    public void Update()
    {
        PlatformMove();
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.name == "Player")
        {
            Debug.Log("I'm colliding");
            coll.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().isKinematic = true;
            coll.transform.parent = transform;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                coll.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }


    public void OnTriggerExit2D(Collider2D coll)
    {
        Debug.Log("I'm no longer colliding");
        coll.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().isKinematic = false;

        Debug.Log("I have detached and made people orphans");
        transform.DetachChildren();
    }





    public void PlatformMove()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, distanceLeft, distanceRight),
            Mathf.Clamp(transform.position.y, distanceUp, distanceDown), transform.position.z);
    }
}
