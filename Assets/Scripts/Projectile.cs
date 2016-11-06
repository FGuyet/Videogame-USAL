using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    if (gameObject.transform.position.x > Screen.width || gameObject.transform.position.x < 0 || gameObject.transform.position.y > Screen.height || gameObject.transform.position.y < 0)
        {
            Object.Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Opponent")
        {
            Debug.Log("Colision Bullet/Opponent");
            Object.Destroy(gameObject);
            Object.Destroy(col.gameObject);
        }
       
    }

}
