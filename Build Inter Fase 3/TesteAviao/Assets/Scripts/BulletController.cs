using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    private Rigidbody corpo;
	// Use this for initialization
	void Start () {
        corpo = GetComponent<Rigidbody>();
        corpo.AddForce(new Vector3(3000, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 80) {
            Destroy(gameObject);
        }
	}
}
