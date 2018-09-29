using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private GameManager _gameManager;
    private GameObject[] _targets;
    private Renderer[] lights;
    public Material destroyedTarget;
    public Material remainingTarget;

    void Start ()
    {
        _gameManager = FindObjectOfType<GameManager>();
        lights = GetComponentsInChildren<Renderer>();
    }
	
	void Update ()
    {
        PrintRemainingTargetsNumber();
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameManager.EnterExitDoor();
    }

    private void PrintRemainingTargetsNumber()
    {
        int unDestroyedTargets = GameObject.FindGameObjectsWithTag("ShootingTarget").Length;
        for (int i = 1; i <= unDestroyedTargets; i++)
        {
            lights[i].GetComponent<Renderer>().material = remainingTarget;
        }
        for (int i = 3; i > unDestroyedTargets; i--)
        {
            lights[i].GetComponent<Renderer>().material = destroyedTarget;
        }
    }
}
