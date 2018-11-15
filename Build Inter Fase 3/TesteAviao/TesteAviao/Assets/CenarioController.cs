using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioController : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.0f);

        if(transform.position.z <= -200)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 400);
        }
	}
}
