﻿using UnityEngine;
using System.Collections;

public class Opponent : GameMember {

    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        MoveTowards(player.transform.position);
	}


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Object.Destroy(col.gameObject);
        }
    }
}
