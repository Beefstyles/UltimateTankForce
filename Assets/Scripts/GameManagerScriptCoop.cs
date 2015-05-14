using UnityEngine;
using System.Collections;
using XInputDotNetPure;
using UnityEngine.UI;



public class GameManagerScriptCoop : CarryOverInfoScript
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
        player1AI = false;
        player2AI = true;
        player3AI = false;
        player4AI = false;
        twoPlayer = true;
        threePlayer = false;
        fourPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {

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
        
    

    }

    void EndGame()
    {
        gameOver = true;
        gameOnScreen.SetActive(false);
        gameOverScreen.SetActive(true);
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
