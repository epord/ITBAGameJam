using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float LevelTimer;
    private float _timer;
    private IEnumerable<ILevelEntity> _levelEntities;

	// Use this for initialization
	void Start () {
        _timer = LevelTimer;
        _levelEntities = FindObjectsOfType<GameObject>().Select(go => go.GetComponent<ILevelEntity>()).Where(a => a != null);
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            Lose();
        }
	}

    private void Reset()
    {
        foreach(var go in _levelEntities)
        {
            go.Reset();
        }
        _timer = LevelTimer;
    }
    
    private void Win(){
    
    }

    private void Lose()
    {
        Reset();
    }

}
