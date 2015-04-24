using UnityEngine;
using System.Collections;
using XInputDotNetPure;
using UnityEngine.UI;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class GameManagerScript : MonoBehaviour
{
     public float p1SpawnTimer, p2SpawnTimer;
     public bool p1Alive, p2Alive;
     public bool p1Spawnable;
     public float xMinPlane = -914, xMaxPlane = 850, yMinPlane = -430, yMaxPlane = 448;
     public GameObject gamePlane;
     public int p1kills, p2kills, p1deaths, p2deaths;
     public Text p1KillCounter, p2KillCounter, p1DeathCounter, p2DeathCounter;
     public Transform p1Spawn, p2Spawn;
     public GameObject p1AI, p2AI;
     public GameObject gameOverScreen;
     public Text PlayerSpawnTimerText;
     GameTimer GameTimer;

    // Use this for initialization
    void Start()
    {
        p1kills = 0;
        p2kills = 0;
        p1deaths = 0;
        p2deaths = 0;
        p1SpawnTimer = 1F;
        p2SpawnTimer = 1F;
        p1Alive = false;
        p2Alive = false;
        GameTimer = FindObjectOfType<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        p1KillCounter.text = p1kills.ToString();
        p2KillCounter.text = p2kills.ToString();
        p1DeathCounter.text = p1deaths.ToString();
        p2DeathCounter.text = p2deaths.ToString();

        if (p2SpawnTimer >= 0)
        {
            p2SpawnTimer -= Time.deltaTime;
        }
        else if (p2SpawnTimer <= 0 && !p2Alive)
        {
            Instantiate(p2AI, p2Spawn.position, Quaternion.identity);
            p2Alive = true;
        }

        if (p1SpawnTimer >= 0)
        {
            p1SpawnTimer -= Time.deltaTime;
            PlayerSpawnTimerText.text = p1SpawnTimer.ToString();
        }
        else if (p1SpawnTimer <= 0 && !p1Alive)
        {
            p1Spawnable = true;
            PlayerSpawnTimerText.text = "";
        }

        if (GameTimer.GameTimerF <= 0)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
