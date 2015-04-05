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
     public float xMinPlane = -914, xMaxPlane = 850, yMinPlane = -430, yMaxPlane = 448;
     public GameObject gamePlane;
     public int p1kills, p2kills, p1deaths, p2deaths;
     public Text p1KillCounter, p2KillCounter, p1DeathCounter, p2DeathCounter;
     
     public GameObject gameOverScreen;
   

    // Use this for initialization
    void Start()
    {
        p1kills = 0;
        p2kills = 0;
        p1deaths = 0;
        p2deaths = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        p1KillCounter.text = p1kills.ToString();
        p2KillCounter.text = p2kills.ToString();
        p1DeathCounter.text = p1deaths.ToString();
        p2DeathCounter.text = p2deaths.ToString();
    }
}
