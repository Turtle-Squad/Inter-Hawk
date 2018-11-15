using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator anim;

    private bool mirar, shot, agachar;

    private bool podeAgachar;

    public Transform cameraTransform;

    public LayerMask enemiesLayer;

    public float soundIntensity = 20f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        podeAgachar = true;
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("aiming", mirar);
        anim.SetBool("shot", shot);
        anim.SetBool("agachar", agachar);

        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            if (podeAgachar == true) {
                agachar = true;
                podeAgachar = false;
                cameraTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y - 0.5f, cameraTransform.position.z);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)) {
            if (podeAgachar == false) {
                agachar = false;
                podeAgachar = true;
                cameraTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y + 0.5f, cameraTransform.position.z);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            mirar = true;
        }
        else if (Input.GetMouseButtonUp(1)) {
            mirar = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (mirar == true)
            {
                Fire();

            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            shot = false;
        }

        var rot = Input.GetAxis("Horizontal") * 2 * Time.deltaTime;
        var speed = Input.GetAxis("Vertical") * 3 * Time.deltaTime;

        
        transform.Translate(rot, 0, speed);
    }

    public void Fire() {
        shot = true;
        Collider[] enemies = Physics.OverlapSphere(transform.position, soundIntensity, enemiesLayer);
        for(int i=0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyController>().OnAware();
        }
    }
}
