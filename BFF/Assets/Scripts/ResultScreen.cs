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

    private int shotsFired;
    private int enemiesKilled;



    // Start is called before the first frame update
    void Start()
    {
        EndResults();

    }

    public void IsDead()
    {

    }

    private void Update()
    {

    }
    public float TotalTime()
    {
        return 0.1f;
    }

    public int TotalEnemies()
    {
        enemiesKilled = 0;
        return enemiesKilled;
    }

    public int TotalShots()
    {
        shotsFired = 0;
        return shotsFired;
    }

    public float TotalAccuracy()
    {
        return (shotsFired / enemiesKilled);
    }

    public void EndResults()
    {

    }
}
