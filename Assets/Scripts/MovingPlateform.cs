using UnityEngine;

public class MovingPlateform : MonoBehaviour
{
    public bool horizontal;
    public bool vertical;
    public bool goRight;
    public bool goUp;
    public float speed;
    public float maxDistance;
    private float origin;
    private Vector2 currentDir;

	void Start () {
        vertical = !horizontal;
        if (horizontal)
        {
            origin = transform.position.x;
        }
        else
        {
            origin = transform.position.y;
        }
        
	}
	
	void FixedUpdate () {
		if (horizontal)
        {
            if (goRight && transform.position.x < origin + maxDistance)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                currentDir = Vector2.right;
            }

            if (goRight && transform.position.x >= origin + maxDistance)
            {
                goRight = false;
            }

            if (!goRight && transform.position.x > origin - maxDistance)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                currentDir = Vector2.left;
            }

            if (!goRight && transform.position.x <= origin - maxDistance)
            {
                goRight = true;
            }
        }
        else if (vertical)
        {
            if (goUp && transform.position.y < origin + maxDistance)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
                currentDir = Vector2.up;
            }

            if (goUp && transform.position.y >= origin + maxDistance)
            {
                goUp = false;
            }

            if (!goUp && transform.position.y > origin - maxDistance)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                currentDir = Vector2.down;
            }

            if (!goUp && transform.position.y <= origin - maxDistance)
            {
                goUp = true;
            }
        }
	}

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name == "Player" && horizontal)
        {
            if (currentDir == Vector2.down)
            {
                collision.gameObject.transform.Translate(currentDir * speed);
            }
            else
            {
                collision.gameObject.transform.Translate(currentDir * speed * Time.deltaTime);
            }
        }
    }
}
