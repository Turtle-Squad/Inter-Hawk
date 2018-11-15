using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvisosLook : MonoBehaviour {
    PlayerController pc;
	// Use this for initialization
	void Start () {
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(pc.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
