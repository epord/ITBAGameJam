using UnityEngine;

public class InGamePauseManager : MonoBehaviour
{
    public bool isGamePaused = false;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isGamePaused)
            { 
                Time.timeScale = 0;
                isGamePaused = true;
            }
            else if (isGamePaused)
            {
                Time.timeScale = 1;
                isGamePaused = false;
            }
        }
    }

    public void PauseWin()
    {
        Invoke("PauseNext", 1f);
    }

    public void PauseLoss()
    {
        Invoke("PauseReset", 0.2f);
    }

    private void PauseNext()
    {
        Application.LoadLevel(gameManager.NextScene);
    }

    private void PauseReset()
    {
        gameManager.Reset();
    }
}