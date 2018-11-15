using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsquadraoController : MonoBehaviour {
    public AviaoController aviaoBot1, aviaoBot2, aviaoBot3, aviaoBot4, aviaoBot5, aviaoBot6, aviaoBot7;

    private float mid, left, rigth, tempoTiro;
    private Vector3 newPosition;
    // Use this for initialization
    void Start () {
        newPosition = transform.position;

        mid = 0.0f;
        left = -11.0f;
        rigth = 11.0f;
    }
	
	// Update is called once per frame
	void Update () {
        PositionChange();

	}

    void PositionChange()
    {
        Vector3 posicaoMid = new Vector3(mid, transform.position.y, transform.position.z);
        Vector3 posicaoLeft = new Vector3(left, transform.position.y, transform.position.z);
        Vector3 posicaoRight = new Vector3(rigth, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (transform.position.x < 1.7f && transform.position.x > -1.7f)
            {
                newPosition = posicaoLeft;
                aviaoBot1.esquerda = true;
                aviaoBot2.esquerda = true;
                aviaoBot3.esquerda = true;
                aviaoBot4.esquerda = true;
                aviaoBot5.esquerda = true;
                aviaoBot6.esquerda = true;
                aviaoBot7.esquerda = true;
                
            }

            if (transform.position.x < 11.1f && transform.position.x > 8.5f)
            {
                newPosition = posicaoMid;
                aviaoBot1.esquerda = true;
                aviaoBot2.esquerda = true;
                aviaoBot3.esquerda = true;
                aviaoBot4.esquerda = true;
                aviaoBot5.esquerda = true;
                aviaoBot6.esquerda = true;
                aviaoBot7.esquerda = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (transform.position.x < 1.7f && transform.position.x > -1.7f)
            {
                newPosition = posicaoRight;
                aviaoBot1.direita = true;
                aviaoBot2.direita = true;
                aviaoBot3.direita = true;
                aviaoBot4.direita = true;
                aviaoBot5.direita = true;
                aviaoBot6.direita = true;
                aviaoBot7.direita = true;
            }
            if (transform.position.x > -11.1f && transform.position.x < -8.5f)
            {

                newPosition = posicaoMid;
                aviaoBot1.direita = true;
                aviaoBot2.direita = true;
                aviaoBot3.direita = true;
                aviaoBot4.direita = true;
                aviaoBot5.direita = true;
                aviaoBot6.direita = true;
                aviaoBot7.direita = true;
            }
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, (Time.deltaTime * 1.5f));
    }
}
