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
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
        }
        else
        {
            // Default ?
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            m_rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
