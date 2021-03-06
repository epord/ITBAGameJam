﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ILevelEntity
{
    public float JumpDistance = 0.1f;
    
    private Vector3 _spawnPosition;
    public float jumpForce = 4.0f;
    public float normalSpeed = 5;
    public float inJumpSpeed = 4;
    public float currentSpeed = 5;
    public GameObject mesh;
    public int TotalLives;
    public int _lives;
    private Rigidbody m_rigidbody;
    private Vector2 currentDir;
    public bool isJumping = false;
    public float additionalJumpForce=2;
    private float additionalForce;
    public float _characterHeight;
    public float RaycastSteps = 10;

    //Invulnerability
    public bool isInvulnerable = false;
    public float invulnerabilityTime;
    public float invulnerabilityStart;
    public float knockBackForce;
    public float decreasingJumpParameter=0.3f;
    public LayerMask Lethal;

    private SoundsManager soundsManager;
    private GameManager _gameManager;
    
    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        _characterHeight = GetComponent<BoxCollider>().size.y;
        currentSpeed = normalSpeed;
        _spawnPosition = transform.position;
        _lives = TotalLives;
        mesh.transform.eulerAngles = new Vector3(-90.0f, 0.0f, 180.0f);
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    void Update()
    {

        var modpos = transform.position;
        modpos.y += JumpDistance / 2;
        RaycastHit hit;
        if (!isInvulnerable && Physics.Raycast(modpos, Vector3.down, out hit, JumpDistance, Lethal))
        {
            _gameManager.Lose();
            return;
        }
        
        if (Time.time - invulnerabilityStart >= invulnerabilityTime && isInvulnerable)
        {
            isInvulnerable = false;
        }

        
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(modpos, Vector3.down, JumpDistance))
        {  
           Vector3 dir = new Vector3(currentDir.x, currentDir.y, 0);
           m_rigidbody.AddForce((Vector3.up * jumpForce) + (dir * inJumpSpeed), ForceMode.Impulse);
           isJumping = true;
           additionalForce = additionalJumpForce;
            soundsManager.PlayJump();
        }
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            m_rigidbody.AddForce(Vector3.up * additionalForce, ForceMode.Impulse);
            if (additionalForce >= decreasingJumpParameter)
            {
                additionalForce -= decreasingJumpParameter;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            additionalForce = additionalJumpForce;
            isJumping = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !CheckCollisionByRaycasting(Vector3.left))
        {
            mesh.transform.eulerAngles = new Vector3(-90.0f, 0.0f, 0.0f);
            currentDir = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !CheckCollisionByRaycasting(Vector3.right))
        {
            mesh.transform.eulerAngles = new Vector3(-90.0f, 0.0f, 180.0f);
            currentDir = Vector2.right;
        }
        else
        {
            currentDir = Vector2.zero;
        }
    }

    bool CheckCollisionByRaycasting(Vector3 direction)
    {
        var step = _characterHeight / RaycastSteps;
        var modpos = transform.position;
        for (double i = 0; i < RaycastSteps; i ++)
        {
            modpos.y += step;
            RaycastHit hit;
            if (Physics.Raycast(modpos, direction, out hit, JumpDistance))
            {
                if (hit.collider.tag == "MapElement")
                {
                    return true;
                }
                
            }
        }
        return false;
    }

    void FixedUpdate()
    {
        var pos = new Vector2(m_rigidbody.position.x, m_rigidbody.position.y);
        m_rigidbody.position = pos + currentDir * currentSpeed * Time.fixedDeltaTime;
    }
    
    
    public void Reset()
    {
        transform.position = _spawnPosition;
        m_rigidbody.velocity = new Vector3();
    }
    
    public int GetHp()
    {
        return _lives;
    }

    public void HitPlayer()
    {
        soundsManager.PlayHit();
        _lives--;
    }

    public bool IsDead()
    {
        return _lives <= 0;
    }

    public void SetInvulnerable(Vector3 direction)
    {
        isInvulnerable = true;
        invulnerabilityStart = Time.time;
        KnockBack(direction);
        MeshRenderer playerRenderer = GetComponentInChildren<MeshRenderer>();
        IEnumerator coroutine = SpriteBlinkingEffect(playerRenderer, 0.1f, invulnerabilityTime);
        StartCoroutine(coroutine);
    }

    private void KnockBack(Vector3 direction)
    {
        m_rigidbody.velocity = direction * knockBackForce;
    }    

    private static IEnumerator SpriteBlinkingEffect(MeshRenderer renderer, float interval, float duration)
    {
        float currentInterval = 0;

        while (duration > 0)
        {
            currentInterval  += Time.deltaTime;
            if(currentInterval >= interval)
            {
                renderer.enabled = !renderer.enabled;
                currentInterval -= interval;
            }
            duration -= Time.deltaTime;
            yield return null;
        }
        renderer.enabled = true;
    }
}
