using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public int gameTimerMinutes;
    public int gameTimerSeconds;
    private string gameTimerSecondsString;
    public Text GameTimerTextMinutes;
    public Text GameTimerTextSeconds;
    private float gameTimerF;

    public float GameTimerF
    {
        get { return gameTimerF; }
        set { gameTimerF = value; }
    }
   
    GameManagerScript GameManager;
	// Use this for initialization
	void Start () {
        
        GameManager = FindObjectOfType<GameManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameTimerF >= 0)
        {
            gameTimerF -= Time.deltaTime;
        }

        gameTimerMinutes = Mathf.FloorToInt(gameTimerF / 60);
        gameTimerSeconds = Mathf.FloorToInt(gameTimerF - (gameTimerMinutes * 60));
        GameTimerTextMinutes.text = gameTimerMinutes.ToString();
        gameTimerSecondsString = gameTimerSeconds.ToString();
        if (gameTimerSecondsString.Length < 2)
        {
            gameTimerSecondsString = "0" + gameTimerSeconds;
        }
        GameTimerTextSeconds.text = gameTimerSecondsString;

	}
}
