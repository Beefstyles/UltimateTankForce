using UnityEngine;
using System.Collections;

public class CarryOverInfoScript : MonoBehaviour
{
    static public int p1WinCounter;
    static public int p2WinCounter;
    static public int roundNoCounter;
    static public int roundNoMax;
    static public bool singlePlayer;
    static public bool AIMatch;
    static public string Player1ShipChoice, Player2ShipChoice;
    static public int stageCharacter;
    static public string currentLevelTitle;
    static public string nextLevelTitle;
    static public bool twoPlayer, threePlayer, fourPlayer;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        currentLevelTitle = "MainArena4Player";
    }
    
    public void ExitToMainMenu()
    {
        Application.LoadLevel("mainMenu");
    }
}
