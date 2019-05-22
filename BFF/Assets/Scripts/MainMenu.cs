using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditPanel;


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("This is the Quit Button");
    }

    public void CreditButton()
    {
        creditPanel.SetActive(true);
    }

    public void BackButton()
    {
        creditPanel.SetActive(false);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
