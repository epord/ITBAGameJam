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

    
}
