using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaoFase3Controller : MonoBehaviour
{

    float velocidadeZ = 60.0f;
    float velocidadeY = 5.0f;
    float velocidadeCam = 8.5f;
    Vector3 target = new Vector3(0, 1.186f, 0);
    public GameObject aviao;
    public GameObject robo;
    public GameObject bullet;
    public bool indo = true;
    public bool voltando = false;
    private Quaternion from;
    private Quaternion to;
    private Quaternion bulletQuat = Quaternion.Euler(-90, 0, 0);
    private float tempoTiro;
    private bool atira;


    // Use this for initialization
    void Start()
    {
        AviaoFase1Controller.podeAtirar = true;
    }

    // Update is called once per frame
    public void Update()
    { 
        //movimentação do avião (vai e volta)
        if (aviao.transform.position.z < target.z - 100 && indo == true)
        {
            aviao.transform.Translate(Vector3.forward * Time.deltaTime * velocidadeZ, Space.World);
            aviao.transform.Translate(Vector3.down * Time.deltaTime * velocidadeY, Space.World);
            aviao.transform.LookAt(target);
            AviaoFase1Controller.podeAtirar = true;
        }
        if (aviao.transform.position.z >= target.z - 100 && aviao.transform.position.z < target.z + 100 && indo ==  true)
        {
            aviao.transform.Translate(Vector3.forward * Time.deltaTime * velocidadeZ, Space.World);
            from = aviao.transform.rotation;
            to = Quaternion.Euler(0, 0, 0);
            float speed = 0.005f;
            aviao.transform.rotation = Quaternion.Slerp(from, to, Time.time * speed); //faz o avião se erguer.
            AviaoFase1Controller.podeAtirar = false;
        }
        if (aviao.transform.position.z >= target.z + 100 && aviao.transform.position.z < target.z + 300 && indo == true)
        {
            aviao.transform.Translate(Vector3.forward * Time.deltaTime * velocidadeZ, Space.World);
            aviao.transform.Translate(Vector3.up * Time.deltaTime * velocidadeY, Space.World);
            from = aviao.transform.rotation;
            to = Quaternion.Euler(-15, 0, 0);
            float speed = 0.005f;
            aviao.transform.rotation = Quaternion.Slerp(from, to, Time.time * speed);
            AviaoFase1Controller.podeAtirar = false;
            RobotFase3Controller.ladoDireito = false;
            RobotFase3Controller.ladoEsquerdo = true;
        }
        if (aviao.transform.position.z >= target.z + 300 && indo == true)
        {
            indo = false;
            aviao.transform.Translate(Vector3.back * Time.deltaTime * velocidadeZ, Space.World);
            aviao.transform.Translate(Vector3.down * Time.deltaTime * velocidadeY, Space.World);
            aviao.transform.LookAt(target);
            AviaoFase1Controller.podeAtirar = false;
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
            AviaoFase1Controller.podeAtirar = true;
        }
        if (aviao.transform.position.z >= target.z - 100 && aviao.transform.position.z < target.z + 100 && indo == false)
        {
            aviao.transform.Translate(Vector3.back * Time.deltaTime * velocidadeZ, Space.World);
            from = aviao.transform.rotation;
            to = Quaternion.Euler(0, 180, 0);
            float speed = 0.005f;
            aviao.transform.rotation = Quaternion.Slerp(from, to, Time.time * speed); //faz o avião se erguer.
            AviaoFase1Controller.podeAtirar = false;
        }
        if (aviao.transform.position.z < target.z - 100 && indo == false)
        {
            aviao.transform.Translate(Vector3.back * Time.deltaTime * velocidadeZ, Space.World);
            aviao.transform.Translate(Vector3.up * Time.deltaTime * velocidadeY, Space.World);
            from = aviao.transform.rotation;
            to = Quaternion.Euler(-15, 180, 0);
            float speed = 0.005f;
            aviao.transform.rotation = Quaternion.Slerp(from, to, Time.time * speed);
            AviaoFase1Controller.podeAtirar = false;
            RobotFase3Controller.ladoDireito = true;
            RobotFase3Controller.ladoEsquerdo = false;
        }
        if (aviao.transform.position.z <= target.z - 300 && indo == false)
        {
            indo = true;
            aviao.transform.Translate(Vector3.back * Time.deltaTime * velocidadeZ, Space.World);
            aviao.transform.Translate(Vector3.down * Time.deltaTime * velocidadeY, Space.World);
            aviao.transform.LookAt(target);
            AviaoFase1Controller.podeAtirar = false;
        }

    }
}