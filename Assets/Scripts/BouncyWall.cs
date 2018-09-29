using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyWall : MonoBehaviour {
    public float WallCollisionForce = 10f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            var player = collision.gameObject.GetComponent<Rigidbody>();

            var vel = player.velocity;
            vel.x = -vel.x;
            player.velocity = vel;
        }
    }
}
