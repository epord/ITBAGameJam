using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycast : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(this.transform.position,
                      this.transform.rotation.eulerAngles,
                      Color.red,
                      0.5f);
	}
}
