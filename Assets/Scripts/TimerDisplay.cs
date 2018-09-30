using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour {
    private GameManager _gameManager;
    private TextMeshProUGUI _textDisplay;
    private float _lastTime;
	// Use this for initialization
	void Start () {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _textDisplay = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
        _textDisplay.SetText(string.Format("{0:0}", _gameManager.Timer()));
	}
}
