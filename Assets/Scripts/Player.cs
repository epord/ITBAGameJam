using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public int normalSpeed;
    public int inJumpSpeed;
    public int currentSpeed;
    private Rigidbody m_rigidbody;
    public bool isJumping;
    private Vector2 currentDir;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        isJumping = false;
        currentSpeed = normalSpeed;
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
        if (collision.gameObject.tag == "MapElement" && isJumping)
        {
            currentSpeed = normalSpeed;
            isJumping = false;
        }
    }
}
