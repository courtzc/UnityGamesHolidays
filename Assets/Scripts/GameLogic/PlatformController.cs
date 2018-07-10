using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public void Start()
    {

    }

    public void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.name == "MovingPlatform")
        {
            transform.parent = coll.transform;
        }
    }


    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.transform.name == "MovingPlatform")
        {
            coll.transform.DetachChildren();
        }
    }
}
