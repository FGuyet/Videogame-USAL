using UnityEngine;
using System.Collections;

public class Player : GameMember {
	   // Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Vector2 target = gameObject.transform.position;

        if (Input.GetKey("up"))
        {
            target += new Vector2(0,1) * speed;
        }

        if (Input.GetKey("down"))
        {
            target += new Vector2(0, -1) * speed;
        }

        if (Input.GetKey("right"))
        {
            target += new Vector2(1,0) * speed;
        }

        if (Input.GetKey("left"))
        {
            target += new Vector2(-1, 0) * speed;
        }

        move(target);
    }

    void move(Vector2 target)
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target, speed * Time.deltaTime);
    }
}
