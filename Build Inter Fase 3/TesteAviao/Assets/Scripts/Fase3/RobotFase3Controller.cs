using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFase3Controller : MonoBehaviour {

    public GameObject roboCima;
    public GameObject roboBaixo;
    public Transform aviao;

    public Animator anim;

    public static bool ladoDireito;
    public static bool ladoEsquerdo;
    public bool idle;

    // Use this for initialization
    void Start () {
        anim.GetComponent<Animator>();
        ladoDireito = true;
        ladoEsquerdo = false;
        idle = true;
    }
	
	// Update is called once per frame
	void Update () {
        roboCima.transform.LookAt(aviao);
        if (ladoDireito == false && ladoEsquerdo == true)
        {
            anim.SetBool("ladoDireito", false);
            anim.SetBool("ladoEsquerdo", true);
        }
    }

    public void TakeDamage(float amount)
    {
        EnemyHealthController.vidaInimigo -= amount;
        if (EnemyHealthController.vidaInimigo <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {

    }
}
