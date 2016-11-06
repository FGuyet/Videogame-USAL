using UnityEngine;
using System.Collections;

public abstract class GameMember : MonoBehaviour {
    public int Pdv;
    public float Speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void MoveTowards(Vector2 target)
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target, Speed * Time.deltaTime);
    }
}
