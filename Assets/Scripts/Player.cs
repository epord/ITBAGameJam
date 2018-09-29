using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ILevelEntity
{
    public float JumpDistance = 0.1f;
    private Vector3 _spawnPosition;
    public float jumpForce = 15.0f;
    public float normalSpeed = 5;
    public float inJumpSpeed = 4;
    public float currentSpeed = 5;
    public GameObject mesh;
    public int TotalLives;
    private int _lives;
    private Rigidbody m_rigidbody;
    private Vector2 currentDir;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        currentSpeed = normalSpeed;
        _spawnPosition = transform.position;
        _lives = TotalLives;
        mesh.transform.eulerAngles = new Vector3(-90.0f, 0.0f, 180.0f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mesh.transform.eulerAngles = new Vector3(-90.0f, 0.0f, 0.0f);
            currentDir = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            mesh.transform.eulerAngles = new Vector3(-90.0f, 0.0f, 180.0f);
            currentDir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            currentDir = Vector2.up;
        }
        else
        {
            currentDir = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, Vector3.down, JumpDistance)) {
                Vector3 dir = new Vector3(currentDir.x, currentDir.y, 0);
                m_rigidbody.AddForce((Vector3.up * jumpForce) + (dir * inJumpSpeed), ForceMode.Impulse);
                currentSpeed = inJumpSpeed * 1.5f;
            }
        }
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
        _lives--;
    }

    public bool IsDead()
    {
        return _lives <= 0;
    }
}
