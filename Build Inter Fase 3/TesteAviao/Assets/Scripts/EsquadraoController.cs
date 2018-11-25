using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsquadraoController : MonoBehaviour {
    public AviaoController aviaoBot1, aviaoBot2, aviaoBot3;

    private float mid, left, rigth, tempoTiro;
    private Vector3 newPosition;
    // Use this for initialization
    void Start () {
        newPosition = transform.position;

        mid = 0.0f;
        left = 11.0f;
        rigth = -11.0f;
    }
	
	// Update is called once per frame
	void Update () {
        PositionChange();

	}

    void PositionChange()
    {
        Vector3 posicaoMid = new Vector3(transform.position.x, transform.position.y, mid);
        Vector3 posicaoLeft = new Vector3(transform.position.x, transform.position.y, left);
        Vector3 posicaoRight = new Vector3(transform.position.x, transform.position.y, rigth);

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (transform.position.z < 1.7f && transform.position.z > -1.7f)
            {
                newPosition = posicaoLeft;
                aviaoBot1.esquerda = true;
                aviaoBot2.esquerda = true;
                aviaoBot3.esquerda = true;
                
            }

            if (transform.position.z < 12f && transform.position.z > 8.5f)
            {
                newPosition = posicaoMid;
                aviaoBot1.esquerda = true;
                aviaoBot2.esquerda = true;
                aviaoBot3.esquerda = true;

            }

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (transform.position.z < 1.7f && transform.position.z > -1.7f)
            {
                newPosition = posicaoRight;
                aviaoBot1.direita = true;
                aviaoBot2.direita = true;
                aviaoBot3.direita = true;

            }
            if (transform.position.z > -12f && transform.position.z < -8.5f)
            {

                newPosition = posicaoMid;
                aviaoBot1.direita = true;
                aviaoBot2.direita = true;
                aviaoBot3.direita = true;

            }
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, (Time.deltaTime * 1.5f));
    }
}
