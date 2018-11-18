using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    string sceneName;
    Scene m_Scene;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            AfterFase1();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            AfterFase2();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            AfterFase3();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            AfterCutsceneFinal();
        }
    }
    public void ChangeScene()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;

        if (sceneName == "Cutscene1")
        {
            AfterCutscene1();
        }
        if (sceneName == "Cutscene2")
        {
            AfterCutscene2();
        }
        if (sceneName == "Cutscene3")
        {
            AfterCutscene3();
        }
        if (sceneName == "CutsceneFinal")
        {
            AfterCutsceneFinal();
        }
    }
    public void AfterMenu()
    {
        SceneManager.LoadScene("Cutscene1");
        Cursor.lockState = CursorLockMode.None;
    }

    public void AfterCutscene1()
    {
        SceneManager.LoadScene("Fase1");
        Cursor.lockState = CursorLockMode.None;
    }

    public void AfterFase1()
    {
        SceneManager.LoadScene("Cutscene2");
        Cursor.lockState = CursorLockMode.None;
    }

    public void AfterCutscene2()
    {
        SceneManager.LoadScene("Fase2");
    }

    public void AfterFase2()
    {
        SceneManager.LoadScene("Cutscene3");
        Cursor.lockState = CursorLockMode.None;
    }

    public void AfterCutscene3()
    {
        SceneManager.LoadScene("Fase3");
        Cursor.lockState = CursorLockMode.None;
    }

    public void AfterFase3()
    {
        SceneManager.LoadScene("CutsceneFinal");
        Cursor.lockState = CursorLockMode.None;
    }

    public void AfterCutsceneFinal()
    {
        SceneManager.LoadScene("Menu");
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
