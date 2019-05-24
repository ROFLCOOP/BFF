using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    public int enemyKill;
    public int shotCount;

    private float timer;
    private int minutes;

    public Text enemyKillText;
    public Text shotCountText;
    public Text timerText;

    public Image fadeToBlack;

    private bool isDead;
    public GunScript gunControl;
    public CharacterControl characterControl;

    public GameObject pauseScreen;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("Esc is pressed");
            PauseButton();
        }
        //isDead = characterControl.PlayerDead;
        if (!isDead && !isPaused)
        {
            timer += Time.deltaTime;
            //enemyKill = gunControl.KillCount;
            //shotCount = gunControl.ShotCount;
        }
        if (timer >= 60)
        {
            minutes++;
            timer = 0;
        }
        timerText.text = minutes.ToString("00") + ":" + timer.ToString("00.00");
    }

    public void PauseButton()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }

        if (isPaused)
            isPaused = false;
        else
            isPaused = true;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void OnDeath()
    {
        isDead = true;
        fadeToBlack.gameObject.SetActive(true);

    }

    public int ReturnKills()
    {
        return enemyKill;
    }

    public int ReturnShots()
    {
        return shotCount;
    }

    public float ReturnTimer()
    {
        return timer + (60 * minutes);
    }

    public void AddKill()
    {
        enemyKill++;
        enemyKillText.text = enemyKill.ToString("000") + " Kills";
    }
    public void AddShot()
    {
        shotCount++;
        shotCountText.text = shotCount.ToString("000") + " Shots";
    }
}
