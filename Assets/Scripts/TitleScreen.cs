using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GUISkin skin;
    public GUISkin titleSkin;
    private bool mainMenu = true;
    private bool controls = false;
    private bool play = false;
    private bool levels = false;
    private SoundsManager soundsManager;

    // UI variables
    private float boxCoordX = 0.05f;
    private float boxCoordY = 0.1f;
    private float boxWidth = 0.4f;
    private float boxHeight = 0.8f;
    private float buttonWidth = 0.3f;
    private float buttonHeight = 0.15f;
    private float allButtonsPosX = 0.08f;
    private float firstButtonPosY = 0.15f;
    private float secondButtonPosY = 0.33f;
    private float thirdButtonPosY = 0.51f;
    private float fourthButtonPosY = 0.69f;
    private float levelButtonFirstX = 0.1f;
    private float levelButtonSecondX = 0.26f;
    private float levelButtonWidth = 0.14f;


    void Start()
    {
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
        soundsManager.PlayLevelLong();
    }

    void Update()
    {
        //if (Input.anyKey)
        //	Application.LoadLevel(1);
    }

    private void OnGUI()
    {
        //GUI.skin = titleSkin;
        //GUI.Label(new Rect(Screen.width * 0.5f, Screen.height * 0.7f, Screen.width * 0.4f, Screen.height * 0.2f), "EXPLOIT");
        GUI.skin = skin;
       // GUI.Box(new Rect(Screen.width * boxCoordX, Screen.height * boxCoordY, Screen.width * boxWidth, Screen.height * boxHeight), "");
        

        if (mainMenu)
        {
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * firstButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("Play", "Play")))
            {
                //mainMenu = false;
                Application.LoadLevel(1);
                //play = true;
                //soundsManager.PlayButtonClick();
            }
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * secondButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("Levels", "Levels")))
            {
                mainMenu = false;
                levels = true;
                //soundsManager.PlayButtonClick();
            }
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * thirdButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("Controls", "Controls")))
            {
                mainMenu = false;
                controls = true;
                //soundsManager.PlayButtonClick();
            }
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * fourthButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("Exit", "Exit")))
            {
                //soundsManager.PlayButtonClick();
                Application.Quit();
            }
        }
        else if (levels)
        {
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * fourthButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("Return", "Return")))
            {
                mainMenu = true;
                levels = false;
                //soundsManager.PlayButtonClick();
            }
            if (GUI.Button(new Rect(Screen.width * levelButtonFirstX, Screen.height * firstButtonPosY, Screen.width * levelButtonWidth, Screen.height * buttonHeight), new GUIContent("Level 1", "Level 1")))
            {
                Application.LoadLevel(1);
                //soundsManager.PlayButtonClick();
            }
            if (GUI.Button(new Rect(Screen.width * levelButtonSecondX + buttonWidth, Screen.height * firstButtonPosY, Screen.width * levelButtonWidth, Screen.height * buttonHeight), new GUIContent("Level 2", "Level 2")))
            {
                Application.LoadLevel(2);
                //soundsManager.PlayButtonClick();
            }
            if (GUI.Button(new Rect(Screen.width * levelButtonFirstX, Screen.height * secondButtonPosY, Screen.width * levelButtonWidth, Screen.height * buttonHeight), new GUIContent("Level 3", "Level 3")))
            {
                Application.LoadLevel(3);
                //soundsManager.PlayButtonClick();
            }
            if (GUI.Button(new Rect(Screen.width * levelButtonSecondX + buttonWidth, Screen.height * secondButtonPosY, Screen.width * levelButtonWidth, Screen.height * buttonHeight), new GUIContent("Level 4", "Level 4")))
            {
                Application.LoadLevel(4);
                //soundsManager.PlayButtonClick();
            }
            if (GUI.Button(new Rect(Screen.width * levelButtonFirstX, Screen.height * thirdButtonPosY, Screen.width * levelButtonWidth, Screen.height * buttonHeight), new GUIContent("Level 5", "Level 5")))
            {
                Application.LoadLevel(5);
                //soundsManager.PlayButtonClick();
            }
            if (GUI.Button(new Rect(Screen.width * levelButtonSecondX + buttonWidth, Screen.height * thirdButtonPosY, Screen.width * levelButtonWidth, Screen.height * buttonHeight), new GUIContent("Level 6", "Level 6")))
            {
                Application.LoadLevel(6);
                //soundsManager.PlayButtonClick();
            }
        }
        else if (controls)
        {
            if (GUI.Button(new Rect(Screen.width * allButtonsPosX, Screen.height * fourthButtonPosY, Screen.width * buttonWidth, Screen.height * buttonHeight), new GUIContent("Return", "Return")))
            {
                mainMenu = true;
                controls = false;
                //soundsManager.PlayButtonClick();
            }
            GUI.Label(new Rect(Screen.width * allButtonsPosX, Screen.height * firstButtonPosY, Screen.width * buttonWidth, Screen.height * 3 * buttonHeight),
                "Move : Left - Right arrows \n" +
                "Jump : Space \n" +
                "Shoot : S \n" +
                "Reset Level : R \n" +
                      "Menu : Escape");
        }
    }
}
