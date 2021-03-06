﻿using UnityEngine;
using System.Collections;
using XInputDotNetPure;
using UnityEngine.UI;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public class TextClass
{
    public Text p1KillCounter, p2KillCounter, p3KillCounter, p4KillCounter, p1DeathCounter, p2DeathCounter, p3DeathCounter, p4DeathCounter;
    public Text finalP1Score, finalP2Score, finalP3Score, finalP4Score;
    public Text player1SpawnTimerText, player2SpawnTimerText, player3SpawnTimerText, player4SpawnTimerText;
}

public class GameManagerScript : CarryOverInfoScript
{
    public float p1SpawnTimer, p2SpawnTimer, p3SpawnTimer, p4SpawnTimer;
     public bool p1Alive, p2Alive, p3Alive, p4Alive;
     public bool p1Spawnable, p2Spawnable, p3Spawnable, p4Spawnable;
     public float xMinPlane = -914, xMaxPlane = 850, yMinPlane = -430, yMaxPlane = 448;
     public GameObject gamePlane;
     public int p1kills, p2kills, p3kills, p4kills, p1deaths, p2deaths, p3deaths, p4deaths;
     private int finalP1ScoreInt, finalP2ScoreInt, finalP3ScoreInt, finalP4ScoreInt;
     public Transform p1Spawn, p2Spawn, p3Spawn, p4Spawn;
     public GameObject p1AI, p2AI, p3AI, p4AI;
     public GameObject gameOverScreen;
     GameTimer GameTimer;
     public TextClass TextClass;
     public GameObject gameOnScreen;
     private bool gameOver;
     public bool player1AI, player2AI, player3AI, player4AI;
     

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1F;
        p1kills = 0;
        p2kills = 0;
        p1deaths = 0;
        p2deaths = 0;
        finalP1ScoreInt = 0;
        finalP2ScoreInt = 0;
        p1SpawnTimer = 1F;
        p2SpawnTimer = 1F;
        p3SpawnTimer = 1F;
        p4SpawnTimer = 1F;
        p1Alive = false;
        p2Alive = false;
        p3Alive = false;
        p4Alive = false;
        GameTimer = FindObjectOfType<GameTimer>();
        gameOnScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        player1AI = false;
        player2AI = true;
        player3AI = true;
        player4AI = true;
        GameTimer.GameTimerF = 10F;
        twoPlayer = true;
        threePlayer = true;
        fourPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        TextClass.p1KillCounter.text = p1kills.ToString();
        TextClass.p2KillCounter.text = p2kills.ToString();
        TextClass.p3KillCounter.text = p3kills.ToString();
        TextClass.p4KillCounter.text = p4kills.ToString();
        TextClass.p1DeathCounter.text = p1deaths.ToString();
        TextClass.p2DeathCounter.text = p2deaths.ToString();
        TextClass.p3DeathCounter.text = p3deaths.ToString();
        TextClass.p4DeathCounter.text = p4deaths.ToString();

        if (twoPlayer)
        {
            if (p1SpawnTimer >= 0)
            {
                p1SpawnTimer -= Time.deltaTime;
                TextClass.player1SpawnTimerText.text = p1SpawnTimer.ToString();
            }
            else if (p1SpawnTimer <= 0 && !p1Alive)
            {
                if (player1AI)
                {
                    Instantiate(p1AI, p1Spawn.position, Quaternion.identity);
                }
                else if (!player1AI)
                {
                    p1Spawnable = true;
                }
                p1Alive = true;
                TextClass.player1SpawnTimerText.enabled = false;
            }

            if (p2SpawnTimer >= 0)
            {
                p2SpawnTimer -= Time.deltaTime;
                TextClass.player2SpawnTimerText.text = p2SpawnTimer.ToString();
            }
            else if (p2SpawnTimer <= 0 && !p2Alive)
            {
                if (player2AI)
                {
                    Instantiate(p2AI, p2Spawn.position, Quaternion.identity);
                }
                if (!player2AI)
                {
                    p2Spawnable = true;
                }
                TextClass.player2SpawnTimerText.text = "";
                p2Alive = true;
            }
        }

        if (threePlayer)
        {
            if (p3SpawnTimer >= 0)
            {
                p3SpawnTimer -= Time.deltaTime;
                TextClass.player3SpawnTimerText.text = p3SpawnTimer.ToString();
            }
            else if (p3SpawnTimer <= 0 && !p3Alive)
            {
                if (player3AI)
                {
                    Instantiate(p3AI, p3Spawn.position, Quaternion.identity);
                }
                if (!player3AI)
                {
                    p3Spawnable = true;
                }
                TextClass.player3SpawnTimerText.text = "";
                p3Alive = true;
            }
        }

        if (fourPlayer)
        {
            if (p4SpawnTimer >= 0)
            {
                p4SpawnTimer -= Time.deltaTime;
                TextClass.player4SpawnTimerText.text = p4SpawnTimer.ToString();
            }
            else if (p4SpawnTimer <= 0 && !p4Alive)
            {
                if (player4AI)
                {
                    Instantiate(p4AI, p4Spawn.position, Quaternion.identity);
                }
                if (!player4AI)
                {
                    p4Spawnable = true;
                }
                TextClass.player4SpawnTimerText.text = "";
                p4Alive = true;
            }
        }
        
        if (p1Alive)
        {
            TextClass.player1SpawnTimerText.text = "";
        }

        if (p2Alive)
        {
            TextClass.player2SpawnTimerText.text = "";
        }

        if (GameTimer.GameTimerF <= 0 && !gameOver)
        {
            EndGame();
            
        }
    }

    void EndGame()
    {
        gameOver = true;
        gameOnScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        GameTimer.GameTimerTextMinutes.text = "";
        GameTimer.GameTimerTextSeconds.text = "";
        finalP1ScoreInt = p1kills - p1deaths;
        finalP2ScoreInt = p2kills - p2deaths;
        finalP3ScoreInt = p3kills - p3deaths;
        finalP4ScoreInt = p4kills - p4deaths;
        TextClass.finalP1Score.text = finalP1ScoreInt.ToString();
        TextClass.finalP2Score.text = finalP2ScoreInt.ToString();
        TextClass.finalP3Score.text = finalP3ScoreInt.ToString();
        TextClass.finalP4Score.text = finalP4ScoreInt.ToString();
        Time.timeScale = 0F;
    }

    public void RestartLevel()
    {
        Application.LoadLevel(currentLevelTitle);
    }
}
