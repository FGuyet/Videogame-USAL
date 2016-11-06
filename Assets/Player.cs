using UnityEngine;
using System.Collections;

public class Player : GameMember {

	// Use this for initialization
	void Start () {
        pdv = 5;
        speed = 1; 
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 movement = new Vector2(0,0);

        if (Input.GetKey("up"))
        {
            movement += new Vector2(0,1);
        }

        if (Input.GetKey("down"))
        {
            movement += new Vector2(0, -1);
        }

        if (Input.GetKey("right"))
        {
            movement += new Vector2(1,0);
        }

        if (Input.GetKey("left"))
        {
            movement += new Vector2(-1, 0);
        }

        move(movement);
    }

    void move(Vector2 direction)
    {
        Vector2 position = gameObject.transform.localPosition;
        Vector2 newPosition = new Vector2(position.x + direction.x, position.y + direction.y);
        gameObject.transform.localPosition = newPosition;
    }
}
