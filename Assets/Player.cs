using UnityEngine;
using System.Collections;
using System;

public class Player : GameMember {
	   // Use this for initialization
	void Start () {

      //  InvokeRepeating("Shoot", 2.0f, 0.3f);
    }
	
	// Update is called once per frame
	void Update () {

        MoveTowards(GetMovementTarget());
    }

    private Vector2 GetMovementTarget()
    {

        Vector2 target = gameObject.transform.position;

        if (Input.GetKey("up"))
        {
            target += new Vector2(0, 1) * speed;
        }

        if (Input.GetKey("down"))
        {
            target += new Vector2(0, -1) * speed;
        }

        if (Input.GetKey("right"))
        {
            target += new Vector2(1, 0) * speed;
        }

        if (Input.GetKey("left"))
        {
            target += new Vector2(-1, 0) * speed;
        }

        return target;
    }
}
