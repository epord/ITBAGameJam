using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float rotateSpeed = 100.0f;
    public GameObject gunMesh;
    public Color shootingColor;
    private LineRenderer shootingLine;
    private bool isMovingRight = true;
    private Vector3 raycastDirection;
    private int _counter;
    public int FramesLineIsOn;
    private SoundsManager soundsManager;

	// Use this for initialization
	void Start () {
        shootingLine = this.GetComponent<LineRenderer>();
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        shootingLine.SetPositions(initLaserPositions);
        shootingLine.SetWidth(0.05f, 0.05f);
        shootingLine.SetColors(shootingColor, shootingColor);
        soundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
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
            this.transform.eulerAngles = new Vector3(0.0f, 0.0f, -90.0f);
            raycastDirection = new Vector3(0.0f, 1.0f, 0.0f);
        }
        else
        {
            this.transform.eulerAngles = this.isMovingRight ? new Vector3(0.0f, 0.0f, 180.0f) : new Vector3(0.0f, 0.0f, 0.0f);
            gunMesh.transform.eulerAngles = this.isMovingRight ? new Vector3(-90.0f, 0.0f, 180.0f) : new Vector3(-90.0f, 0.0f, 0.0f);
            this.raycastDirection = this.isMovingRight ? new Vector3(1.0f, 0.0f, 0.0f) : new Vector3(-1.0f, 0.0f, 0.0f);
        }
    }

    private void shoot()
    {
        shootingLine.SetPosition(0, gunMesh.transform.position);
        soundsManager.PlayShoot();
        int playerLayerMask = 1 << 8;
        RaycastHit hit;
        if (Physics.Raycast(gunMesh.transform.position, raycastDirection, out hit, Mathf.Infinity, ~playerLayerMask))
        {
            shootingLine.SetPosition(1, hit.point);

            if (hit.transform.gameObject.tag == "ShootingTarget")
            {
                Destroy(hit.transform.gameObject);
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
            _counter = FramesLineIsOn;
        } else {
            _counter--;
            if (_counter < 0)
            {
                shootingLine.enabled = false;
            }
        }
    }
}