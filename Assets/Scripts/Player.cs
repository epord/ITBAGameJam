using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ILevelEntity
{
    private Vector3 _spawnPosition;
    public float jumpForce;
    public int normalSpeed;
    public int inJumpSpeed;
    public int currentSpeed;
    public int TotalLives;
    private int _lives;
    private Rigidbody m_rigidbody;
    public bool isJumping;
    private Vector2 currentDir;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        isJumping = false;
        currentSpeed = normalSpeed;
        _spawnPosition = transform.position;
        _lives = TotalLives;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!isJumping)
            {
                currentDir = Vector2.left;
                transform.Translate(currentDir * currentSpeed * Time.deltaTime);
            }
            else if (isJumping)
            {
                if (currentDir != Vector2.left)
                {
                    if (currentDir == Vector2.right)
                    {
                        currentDir = Vector2.left;
                        m_rigidbody.AddForce(currentDir * 2 * currentSpeed, ForceMode.Impulse);
                    }
                    else
                    {
                        currentDir = Vector2.left;
                        m_rigidbody.AddForce(currentDir * currentSpeed, ForceMode.Impulse);
                    }
                }
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!isJumping)
            {
                currentDir = Vector2.right;
                transform.Translate(currentDir * currentSpeed * Time.deltaTime);
            }
            else if (isJumping)
            {
                if (currentDir != Vector2.right)
                {
                    if(currentDir == Vector2.left)
                    {
                        currentDir = Vector2.right;
                        m_rigidbody.AddForce(currentDir * 2 * currentSpeed, ForceMode.Impulse);
                    }
                    else
                    {
                        currentDir = Vector2.right;
                        m_rigidbody.AddForce(currentDir * currentSpeed, ForceMode.Impulse);
                    }
                }
            }

        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            currentDir = Vector2.up;
        }

        if (!isJumping && !Input.anyKeyDown)
        {
            currentDir = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Vector3 dir = new Vector3(currentDir.x, currentDir.y, 0);
            m_rigidbody.AddForce((Vector3.up * jumpForce) + (dir * inJumpSpeed), ForceMode.Impulse);
            isJumping = true;
            currentSpeed = inJumpSpeed;
        }
}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MapElement" && isJumping && collision.contacts[0].point.y < transform.position.y)
        {
            currentSpeed = normalSpeed;
            isJumping = false;
        }
    }
    
    public void Reset()
    {
        transform.position = _spawnPosition;
        m_rigidbody.velocity = new Vector3();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "MapElement")
        {
            currentSpeed = inJumpSpeed;
            isJumping = true;
        }
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
