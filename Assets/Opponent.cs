using UnityEngine;
using System.Collections;

public class Opponent : GameMember {

    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
	}
	
	// Update is called once per frame
	void Update () {
        moveTo(player);
	}

    void moveTo(GameObject player)
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
