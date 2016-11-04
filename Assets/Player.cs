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
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Move up");
            move(new Vector2(1,1));
        }
    }

    void move(Vector2 direction)
    {
        Vector2 position = gameObject.transform.localPosition;
        Vector2 newPosition = new Vector2(position.x + direction.x, position.y + direction.y);
        gameObject.transform.localPosition = newPosition;
    }
}
