using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaoController : MonoBehaviour {
    private float mid, left, rigth, tempoTiro;
    public GameObject bullet;
    private bool atira, moveDireita, moveEsquerda;
    private Animator anim;
    private Vector3 newPosition;

    public bool esquerda, direita;
    // Use this for initialization
    void Start () {
        mid = 0.0f;
        left = -11.0f;
        rigth = 11.0f;
        atira = false;
        

        newPosition = transform.position;

        esquerda = direita = false;

        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        PositionChange();

        anim.SetBool("esquerda", esquerda);
        anim.SetBool("direita", direita);


        if (Input.GetMouseButton(0)){

            if (tempoTiro <= 0) {
                Instantiate(bullet, new Vector3(transform.position.x - 1.7f, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(bullet, new Vector3(transform.position.x + 1.7f, transform.position.y, transform.position.z), Quaternion.identity);
            }
            atira = true;
        }

        if (atira == true)
        {
            tempoTiro += Time.deltaTime;
            if (tempoTiro > 0.15f)
            {
                tempoTiro = 0;
                atira = false;
            }
        }
    }

    void PositionChange() {
        Vector3 posicaoMid = new Vector3(mid, transform.position.y, transform.position.z);
        Vector3 posicaoLeft = new Vector3(left, transform.position.y, transform.position.z);
        Vector3 posicaoRight = new Vector3(rigth, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (transform.position.x < 1.7f && transform.position.x > -1.7f)
            {
                //newPosition = posicaoLeft;
                esquerda = true;
            }

            if (transform.position.x < 11.1f && transform.position.x > 8.5f)
            {
                //newPosition = posicaoMid;
                esquerda = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (transform.position.x < 1.7f && transform.position.x > -1.7f)
            {
                //newPosition = posicaoRight;
                direita = true;
            }
            if (transform.position.x > -11.1f && transform.position.x < -8.5f)
            {
                
                //newPosition = posicaoMid;
                direita = true;
            }
        }

        //transform.position = Vector3.Lerp(transform.position, newPosition, (Time.deltaTime * 1.5f));
    }

    void ParaEsquerda() {
        esquerda = false;
    }

    void ParaDireita()
    {
        direita = false;
    }
}
