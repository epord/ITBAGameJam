using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePowerUp : MonoBehaviour {
    public float TimeDelta;

    private GameManager _gameManager;

	// Use this for initialization
	void Start () {
        _gameManager = FindObjectOfType<GameManager>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            _gameManager.AddTime(TimeDelta);
            Destroy(gameObject);
        }
    }
}
