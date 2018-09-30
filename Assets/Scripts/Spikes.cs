using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private GameManager gameManager;

	void Start ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player" && !collision.gameObject.GetComponent<Player>().isInvulnerable)
        {
            gameManager.Lose();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name == "Player" && !collision.gameObject.GetComponent<Player>().isInvulnerable)
        {
            gameManager.Lose();
        }
    }
}
