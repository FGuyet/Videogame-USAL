using UnityEngine;
using System.Collections;

public abstract class GameMember : MonoBehaviour {
    public int pdv;
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void MoveTowards(Vector2 target)
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target, speed * Time.deltaTime);
    }
}
