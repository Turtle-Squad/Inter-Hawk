using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioController : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z);

        if(transform.position.x <= -200)
        {
            transform.position = new Vector3(200, transform.position.y, transform.position.z);
        }
	}
}
