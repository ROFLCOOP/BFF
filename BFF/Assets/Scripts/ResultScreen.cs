using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{

    public Text totalTime;
    public Text totalEnemies;
    public Text totalShots;
    public Text totalAccuracy;

    private float shotsFired;
    private float enemiesKilled;

    public HUDController HUDController;

    private void OnEnable()
    {
        EndResults();
    }

    public void EndResults()
    {
        float timer = 0;
        float minute = 0;
        timer = HUDController.ReturnTimer();
        if(timer > 60)
        {
            minute = timer / 60;
            timer -= (int)minute * 60;
            
        }
        totalTime.text = minute.ToString("00") + ":" + timer.ToString("00.00");

        enemiesKilled = HUDController.ReturnKills();
        shotsFired = HUDController.ReturnShots();

        totalEnemies.text = enemiesKilled.ToString();
        totalShots.text = shotsFired.ToString();
        float accuracy = (enemiesKilled / shotsFired)*100;
        totalAccuracy.text = accuracy.ToString("F2");
    }
}
