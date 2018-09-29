using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour {
    private Player _player;
    private TextMeshProUGUI _text;

	// Use this for initialization
	void Start () {
        _player = FindObjectOfType<Player>();
        _text = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
        _text.SetText(string.Format("Lives: {0}", _player.GetHp()));
	}
}
