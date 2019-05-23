using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditPanel;

    public GameObject buttonsub;


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
        buttonsub.gameObject.SetActive(false);
    }

    public void BackButton()
    {
        creditPanel.SetActive(false);
        buttonsub.gameObject.SetActive(true);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
