using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float LevelTimer;
    public int Scene;
    private float _timer;
    private IEnumerable<ILevelEntity> _levelEntities;
    private Player _player;

    private bool _doorReached;

	// Use this for initialization
	void Start () {
        _timer = LevelTimer;
        _levelEntities = FindObjectsOfType<GameObject>().Select(go => go.GetComponent<ILevelEntity>()).Where(a => a != null);
        _player = FindObjectOfType<Player>();   
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

        _timer -= Time.deltaTime;
        if (_timer <= 0.001 || _player.IsDead())
        {
            Lose();
        }
        if (_doorReached)
        {
            Win();
        }
	}

    private void Reset()
    {
        Application.LoadLevel(Scene);
        //foreach(var go in _levelEntities)
        //{
        //    go.Reset();
        //}
        //_timer = LevelTimer;
        //_doorReached = false;
    }
    
    private void Win(){
        Reset();
    }

    public void Lose()
    {
        Reset();
    }
    
    public float Timer()
    {
        return _timer;
    }

    public void EnterExitDoor()
    {
        _doorReached = true;
    }

    public void AddTime(float time)
    {
        _timer += time;
        if (_timer < 0)
        {
            _timer += LevelTimer;
        } else if (_timer >= LevelTimer)
        {
            _timer -= LevelTimer;
        }
    }
}
