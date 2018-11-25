using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioController : MonoBehaviour {

    public GameObject terrain1, terrain2;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z);

        if(transform.position.x <= -1800)
        {
            
            terrain2.SetActive(true);
            //transform.position = new Vector3(-40f, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -2400)
        {
            terrain1.SetActive(false);
        }

    }
}
