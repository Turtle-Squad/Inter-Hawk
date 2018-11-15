using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    private Rigidbody corpo;
	// Use this for initialization
	void Start () {
        corpo = GetComponent<Rigidbody>();
        corpo.AddForce(new Vector3(0, 0, 3000));
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z > 80) {
            Destroy(gameObject);
        }
	}
}
