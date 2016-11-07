using UnityEngine;
using System.Collections;
using System;

public class Player : GameMember {
    float shootingRate = 0.5f;

    public GameObject projectile;

    // Use this for initialization
    void Start () {

       // InvokeRepeating("Shoot", 1.0f, shootingRate);
    }
	
	// Update is called once per frame
	void Update () {
        Shoot();
        MoveTowards(GetMovementTarget());
    }

    private Vector2 GetMovementTarget()
    {

        Vector2 target = gameObject.transform.position;

        if (Input.GetKey("z"))
        {
            target += new Vector2(0, 1) * Speed;
        }

        if (Input.GetKey("s"))
        {
            target += new Vector2(0, -1) * Speed;
        }

        if (Input.GetKey("d"))
        {
            target += new Vector2(1, 0) * Speed;
        }

        if (Input.GetKey("q"))
        {
            target += new Vector2(-1, 0) * Speed;
        }

        return target;
    }

    private void Shoot()
    {
        //Direction
        Vector2 target = new Vector2(0, 0);

        if (Input.GetKeyDown("up"))
        {
            target += new Vector2(0, 1);
        }

        if (Input.GetKeyDown("down"))
        {
            target += new Vector2(0, -1);
        }

        if (Input.GetKeyDown("right"))
        {
            target += new Vector2(1, 0);
        }

        if (Input.GetKeyDown("left"))
        {
            target += new Vector2(-1, 0);
        }

        if (target == Vector2.zero)
        {
            return;
        }

        GameObject instance = Instantiate(projectile);

        //Set canvas, initial position, and speed 
        instance.transform.SetParent(GameObject.Find("GameCanvas").transform);
        instance.transform.position = gameObject.transform.position;
        instance.GetComponent<Rigidbody2D>().velocity = target * Speed *1.5f;
    }
}
