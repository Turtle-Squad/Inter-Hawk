using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEController : MonoBehaviour
{
    public GameObject displayBox;
    public GameObject passBox;
    public GameObject displayAll;
    public GameObject LaserBeam, LaserBeamEnd;
    static public bool playerHitado;
    public int QTEgen;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;

    void Start()
    {
        WaitingForKey = 1;
        StartCoroutine(AtStartCountDown());
    }
    void Update()
    {
        if (WaitingForKey == 0)
        {
            QTEgen = Random.Range(1, 4);
            CountingDown = 1;
            StartCoroutine(CountDown());

            if (QTEgen == 1)
            {
                WaitingForKey = 1;
                displayBox.GetComponent<Text>().text = "D";
            }
            if (QTEgen == 2)
            {
                WaitingForKey = 1;
                displayBox.GetComponent<Text>().text = "A";
            }
            if (QTEgen == 3)
            {
                WaitingForKey = 1;
                displayBox.GetComponent<Text>().text = "W";
            }
        }

        if (QTEgen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("DKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else if (Input.GetButtonDown("Fire1"))
                {
                    return;
                } else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (QTEgen == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("AKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else if (Input.GetButtonDown("Fire1"))
                {
                    return;
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (QTEgen == 3)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("WKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else if (Input.GetButtonDown("Fire1"))
                {
                    return;
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }

    IEnumerator KeyPressing()
    {
        QTEgen = 4;
        if(CorrectKey == 1)
        {
            CountingDown = 2;
            passBox.GetComponent<Text>().text = "OK!";

            yield return new WaitForSeconds(1.5f);

            displayAll.SetActive(false);
            CorrectKey = 0;
            passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";

            yield return new WaitForSeconds(Random.Range(1.5f, 3.0f));

            displayAll.SetActive(true);
            WaitingForKey = 0;
            CountingDown = 1;
        }
        if (CorrectKey == 2)
        {
            CountingDown = 2;
            playerHitado = true;
            passBox.GetComponent<Text>().text = "-1 HEALTH";
            LaserBeam.SetActive(true);
            LaserBeamEnd.SetActive(true);
            HealthController.vida -= 20f;

            yield return new WaitForSeconds(1.5f);

            LaserBeam.SetActive(false);
            LaserBeamEnd.SetActive(false);
            displayAll.SetActive(false);
            CorrectKey = 0;
            passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";

            yield return new WaitForSeconds(Random.Range(1.5f, 3.0f));

            playerHitado = false;
            displayAll.SetActive(true);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3.5f);
        if (CountingDown == 1)
        {
            QTEgen = 4;
            CountingDown = 2;
            playerHitado = true;
            LaserBeam.SetActive(true);
            LaserBeamEnd.SetActive(true);
            passBox.GetComponent<Text>().text = "-1 HEALTH";
            HealthController.vida -= 20f;
            yield return new WaitForSeconds(1.5f);
            LaserBeam.SetActive(false);
            LaserBeamEnd.SetActive(false);
            CorrectKey = 0;
            passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(Random.Range(1.5f, 3.0f));
            WaitingForKey = 0;
            CountingDown = 1;
            playerHitado = false;

        }
    }
    
    IEnumerator AtStartCountDown()
    {
        yield return new WaitForSeconds(10.0f);
        displayAll.SetActive(true);
        WaitingForKey = 0;
    }
}