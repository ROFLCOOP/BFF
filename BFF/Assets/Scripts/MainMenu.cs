using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * Simplistic Main menu script with an added DontDestroyOnLoad added on awake to make sure
 * the cursor is the same throughout the game itself
 * 
 * Also includes displaying and hiding the credits while on the main screen
 * */
public class MainMenu : MonoBehaviour
{
    public GameObject creditPanel;
    public GameObject buttonsub;

    public GameObject cursorControl;

    
    private void Awake()
    {
        DontDestroyOnLoad(cursorControl);
    }

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
