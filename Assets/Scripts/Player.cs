using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ILevelEntity
{
    private Vector3 _spawnPosition;
    public float jumpForce = 15.0f;
    public int normalSpeed = 5;
    public int inJumpSpeed = 4;
    public int currentSpeed = 5;
    public GameObject mesh;
    public int TotalLives;
    private int _lives;
    private Rigidbody m_rigidbody;
    public bool isJumping;
    private Vector2 currentDir;
    private int collisionCounter;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        isJumping = false;
        currentSpeed = normalSpeed;
        _spawnPosition = transform.position;
        _lives = TotalLives;
        collisionCounter = 0;
        mesh.transform.eulerAngles = new Vector3(-90.0f, 0.0f, 180.0f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mesh.transform.eulerAngles = new Vector3(-90.0f, 0.0f, 0.0f);
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
            mesh.transform.eulerAngles = new Vector3(-90.0f, 0.0f, 180.0f);
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
            collisionCounter++;
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
            collisionCounter--;
            if(collisionCounter == 0)
            {
                currentSpeed = inJumpSpeed;
                isJumping = true;
            }
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
