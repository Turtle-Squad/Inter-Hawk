using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaoFase3Controller : MonoBehaviour
{

    float velocidadeZ = 40.0f;
    float velocidadeY = 5.0f;
    float velocidadeCam = 8.5f;
    Vector3 target = new Vector3(0, 1.186f, 0);
    public GameObject aviao;
    public GameObject robo;
    public GameObject bullet;
    public bool indo = true;
    public bool voltando = false;
    public bool podeAtirar;
    private Quaternion from;
    private Quaternion to;
    private float tempoTiro;
    private bool atira;

    // Use this for initialization
    void Start()
    {
        podeAtirar = true;
    }

    // Update is called once per frame
    public void Update()
    {
        //tiro
        if (podeAtirar == true)
        {
            if (Input.GetMouseButton(0))
            {

                if (tempoTiro <= 0)
                {
                    Instantiate(bullet, new Vector3(aviao.transform.position.x - 1.7f, aviao.transform.position.y, aviao.transform.position.z), Quaternion.identity);
                    Instantiate(bullet, new Vector3(aviao.transform.position.x + 1.7f, aviao.transform.position.y, aviao.transform.position.z), Quaternion.identity);
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
       
        //movimentação do avião (vai e volta)
        if (aviao.transform.position.z < target.z - 100 && indo == true)
        {
            aviao.transform.Translate(Vector3.forward * Time.deltaTime * velocidadeZ, Space.World);
            aviao.transform.Translate(Vector3.down * Time.deltaTime * velocidadeY, Space.World);
            aviao.transform.LookAt(target);
            podeAtirar = true;
        }
        if (aviao.transform.position.z >= target.z - 100 && aviao.transform.position.z < target.z + 100 && indo ==  true)
        {
            aviao.transform.Translate(Vector3.forward * Time.deltaTime * velocidadeZ, Space.World);
            from = aviao.transform.rotation;
            to = Quaternion.Euler(0, 0, 0);
            float speed = 0.005f;
            aviao.transform.rotation = Quaternion.Slerp(from, to, Time.time * speed); //faz o avião se erguer.
            podeAtirar = false;
        }
        if (aviao.transform.position.z >= target.z + 100 && aviao.transform.position.z < target.z + 300 && indo == true)
        {
            aviao.transform.Translate(Vector3.forward * Time.deltaTime * velocidadeZ, Space.World);
            aviao.transform.Translate(Vector3.up * Time.deltaTime * velocidadeY, Space.World);
            from = aviao.transform.rotation;
            to = Quaternion.Euler(-15, 0, 0);
            float speed = 0.005f;
            aviao.transform.rotation = Quaternion.Slerp(from, to, Time.time * speed);
            podeAtirar = false;
        }
        if (aviao.transform.position.z >= target.z + 300 && indo == true)
        {
            indo = false;
            aviao.transform.Translate(Vector3.back * Time.deltaTime * velocidadeZ, Space.World);
            aviao.transform.Translate(Vector3.down * Time.deltaTime * velocidadeY, Space.World);
            aviao.transform.LookAt(target);
            podeAtirar = false;
        }
        if (aviao.transform.position.z >= target.z + 100 && aviao.transform.position.z < target.z + 300 && indo == false)
        {
            aviao.transform.Translate(Vector3.back * Time.deltaTime * velocidadeZ, Space.World);
            aviao.transform.Translate(Vector3.down * Time.deltaTime * velocidadeY, Space.World);
            from = aviao.transform.rotation;
            to = Quaternion.Euler(-15, 0, 0);
            float speed = 0.005f;
            aviao.transform.rotation = Quaternion.Slerp(from, to, Time.time * speed);
            aviao.transform.LookAt(target);
            podeAtirar = true;
        }
        if (aviao.transform.position.z >= target.z - 100 && aviao.transform.position.z < target.z + 100 && indo == false)
        {
            aviao.transform.Translate(Vector3.back * Time.deltaTime * velocidadeZ, Space.World);
            from = aviao.transform.rotation;
            to = Quaternion.Euler(0, 180, 0);
            float speed = 0.005f;
            aviao.transform.rotation = Quaternion.Slerp(from, to, Time.time * speed); //faz o avião se erguer.
            podeAtirar = false;
        }
        if (aviao.transform.position.z < target.z - 100 && indo == false)
        {
            aviao.transform.Translate(Vector3.back * Time.deltaTime * velocidadeZ, Space.World);
            aviao.transform.Translate(Vector3.up * Time.deltaTime * velocidadeY, Space.World);
            from = aviao.transform.rotation;
            to = Quaternion.Euler(-15, 180, 0);
            float speed = 0.005f;
            aviao.transform.rotation = Quaternion.Slerp(from, to, Time.time * speed);
            podeAtirar = false;
        }
        if (aviao.transform.position.z <= target.z - 300 && indo == false)
        {
            indo = true;
            aviao.transform.Translate(Vector3.back * Time.deltaTime * velocidadeZ, Space.World);
            aviao.transform.Translate(Vector3.down * Time.deltaTime * velocidadeY, Space.World);
            aviao.transform.LookAt(target);
            podeAtirar = false;
        }

    }
}