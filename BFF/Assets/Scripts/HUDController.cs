using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        isDead = characterControl.PlayerDead;
        if (!isDead)
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
