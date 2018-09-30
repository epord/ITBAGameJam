using UnityEngine;

public class InGamePauseManager : MonoBehaviour
{
    public bool isGamePaused = false;
    public bool win;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused && !win)
            { 
                Time.timeScale = 1;
                isGamePaused = false;
                gameManager.Reset();
            }
            else if (isGamePaused && win)
            {
                Time.timeScale = 1;
                isGamePaused = false;
                Application.LoadLevel(gameManager.NextScene);
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        isGamePaused = true;
    }
}