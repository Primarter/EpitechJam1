using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadFirstScene()
    {
        SceneManager.LoadScene("IntroGame");
    }

    public void QuitterJeu()
    {
        Application.Quit();
    }
}
