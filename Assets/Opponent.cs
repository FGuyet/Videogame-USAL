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
        MoveTowards(player.transform.position);
	}
}
