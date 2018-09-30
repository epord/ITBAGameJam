using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float InitialTimer;
    public float LevelTimer;
    public int Scene;
    public int NextScene;
    private float _timer;
    private IEnumerable<ILevelEntity> _levelEntities;
    private Player _player;
    private SoundsManager soundsManager;
    private bool _doorReached;
    private InGamePauseManager inGamePauseManager;

	// Use this for initialization
	void Start () {
        _timer = InitialTimer;
        _levelEntities = FindObjectsOfType<GameObject>().Select(go => go.GetComponent<ILevelEntity>()).Where(a => a != null);
        _player = FindObjectOfType<Player>();
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
        inGamePauseManager = GameObject.Find("InGamePauseManager").GetComponent<InGamePauseManager>();
        soundsManager.PlayLevelLong();
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

    public void Reset()
    {
        Application.LoadLevel(Scene);
        //foreach(var go in _levelEntities)
        //{
        //    go.Reset();
        //}
        //_timer = LevelTimer;
        //_doorReached = false;
    }
    
    private void Win()
    {
        soundsManager.PlayWin();
        inGamePauseManager.win = true;
        inGamePauseManager.Pause();
    }

    public void Lose()
    {
        soundsManager.PlayTimeOut();
        inGamePauseManager.win = false;
        inGamePauseManager.Pause();
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
