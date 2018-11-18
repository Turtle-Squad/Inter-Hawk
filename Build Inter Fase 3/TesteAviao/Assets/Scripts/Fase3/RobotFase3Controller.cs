using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFase3Controller : MonoBehaviour {

    public GameObject roboCima;
    public GameObject roboBaixo;
    public Transform aviao;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        roboCima.transform.LookAt(aviao);
    }
}
