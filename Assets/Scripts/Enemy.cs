using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int spawningTime;
    public int respawnTime;
    public int speed;
    public bool goRight;
    public GameObject mesh;
    private Vector2 direction;
    public GameObject limitWall;
    private float startTime;
    private Vector2 origin;

	void Start ()
    {
        origin = this.transform.position;
        mesh.GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        if (goRight)
        {
            direction = Vector2.right;
        }
        else if (!goRight)
        {
            direction = Vector2.left;
        }
        startTime = Time.time;
	}
	
	void FixedUpdate ()
    {
        if(Time.time - startTime >= spawningTime)
        {
            mesh.GetComponent<Renderer>().enabled = true;
            GetComponent<Collider>().enabled = true;

            if (goRight)
            {
                if (transform.position.x < limitWall.transform.position.x)
                {
                    transform.Translate(direction * speed * Time.deltaTime);
                }
                else
                {
                    mesh.GetComponent<Renderer>().enabled = false;
                    GetComponent<Collider>().enabled = false;
                    startTime = Time.time;
                    spawningTime = respawnTime;
                    transform.position = origin;
                }
            }
            else if (!goRight)
            {
                if (transform.position.x > limitWall.transform.position.x)
                {
                    transform.Translate(direction * speed * Time.deltaTime);
                }
                else
                {
                    mesh.GetComponent<Renderer>().enabled = false;
                    GetComponent<Collider>().enabled = false;
                    startTime = Time.time;
                    spawningTime = respawnTime;
                    transform.position = origin;
                }
            }
        }
        
	}

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (other.gameObject.name == "Player")
        {
            if (player.isInvulnerable == false)
            {
                player.HitPlayer();
                Vector3 temp = transform.position - other.gameObject.transform.position;
                if(temp.x > 0)
                {
                    player.SetInvulnerable(Vector3.left+Vector3.up*1.5f);
                }
                else
                {
                    player.SetInvulnerable(Vector3.right+Vector3.up*1.5f);
                }
            }
        }
    }
}
