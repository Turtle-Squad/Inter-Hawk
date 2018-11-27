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
    public GameObject smoke1, smoke2;
    public FadeUI fadeui;

	// Use this for initialization
	void Start () {
        barraDeVida = GetComponent<Image>();
        fadeui.GetComponent<CanvasGroup>();
        vida = vidaMaxima;
	}
	
	// Update is called once per frame
	void Update () {
        barraDeVida.fillAmount = vida / vidaMaxima;

        if(vida <= 40f)
        {
            smoke1.SetActive(true);
        }
        if(vida <= 20f)
        {
            smoke2.SetActive(true);
        }
        if(vida <= 0)
        {
            FadeUI.derrotafase3 = true;
            derrotaPanel.SetActive(true);
            Invoke("ReloadLevel", 3.0f);
        }
	}

    void ReloadLevel()
    {
        SceneManager.LoadScene("Fase3");
    }
}
