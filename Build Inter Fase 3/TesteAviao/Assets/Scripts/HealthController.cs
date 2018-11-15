using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour {

    Image barraDeVida;
    public GameObject derrotaPanel;
    public static float vida;
    float vidaMaxima = 60f;

	// Use this for initialization
	void Start () {
        barraDeVida = GetComponent<Image>();
        vida = vidaMaxima;
	}
	
	// Update is called once per frame
	void Update () {
        barraDeVida.fillAmount = vida / vidaMaxima;

        if(vida <= 0)
        {
            derrotaPanel.SetActive(true);
            Invoke("ReloadLevel", 3.0f);
        }
	}

    void ReloadLevel()
    {
        SceneManager.LoadScene("Fase3");
    }
}
