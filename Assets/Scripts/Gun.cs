using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float rotateSpeed = 100.0f;
    public GameObject gunMesh;
    private LineRenderer shootingLine;
    private bool isMovingRight = true;
    private Vector3 raycastDirection;

	// Use this for initialization
	void Start () {
        shootingLine = this.GetComponent<LineRenderer>();
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        shootingLine.SetPositions(initLaserPositions);
        shootingLine.SetWidth(0.1f, 0.1f);

        raycastDirection = new Vector3(0.0f, 0.0f, 0.0f);
	}
	
    private void changeGunDirection()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isMovingRight = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isMovingRight = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
            raycastDirection = new Vector3(0.0f, 1.0f, 0.0f);
        }
        else
        {
            this.transform.eulerAngles = this.isMovingRight ? new Vector3(0.0f, 0.0f, 0.0f) : new Vector3(0.0f, 0.0f, 180.0f);
            this.raycastDirection = this.isMovingRight ? new Vector3(1.0f, 0.0f, 0.0f) : new Vector3(-1.0f, 0.0f, 0.0f);
        }
    }

    private void shoot()
    {
        shootingLine.SetPosition(0, gunMesh.transform.position);
     
        int playerLayerMask = 1 << 8;
        RaycastHit hit;
        if (Physics.Raycast(gunMesh.transform.position, raycastDirection, out hit, Mathf.Infinity, ~playerLayerMask))
        {
            shootingLine.SetPosition(1, hit.point);

            if (hit.transform.gameObject.tag == "ShootingTarget")
            {
                Debug.Log("Target!!");
            }
            else
            {
                Debug.Log("Wall...");
            }
        } else {
            shootingLine.SetPosition(1, raycastDirection * 100000);
        }
    }

    public void Update()
    {
        changeGunDirection();

        if (Input.GetKeyDown(KeyCode.S)) {
            shootingLine.enabled = true;
            shoot();
        } else {
            shootingLine.enabled = false;
        }
    }
}