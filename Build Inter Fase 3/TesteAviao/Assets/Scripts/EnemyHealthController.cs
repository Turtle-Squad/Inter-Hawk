using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour {

    Image barraDeVidaInimigo;
    public static float vidaInimigo;
    float vidaMaximaInimigo = 500f;
    // Use this for initialization
    void Start () {
        barraDeVidaInimigo = GetComponent<Image>();
        vidaInimigo = vidaMaximaInimigo;
    }
	
	// Update is called once per frame
	void Update () {
        barraDeVidaInimigo.fillAmount = vidaInimigo / vidaMaximaInimigo;

        if (vidaInimigo <= 0)
        {

        }
    }
}
