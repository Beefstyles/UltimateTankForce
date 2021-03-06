﻿using UnityEngine;
using System.Collections;
using XInputDotNetPure;
using UnityEngine.UI;

public class playerSpawn_p2 : MonoBehaviour
{
    public PlayerIndex playerIndex;
    public GameObject player;
    public GameObject playerInstance;
    uint lastPacketNumber;
    float lastPacketTime;
    public Text PlayerSpawnText;
    //GameManagerScript GameManagerScript;
    GameManagerScriptCoop GameManagerScript;
    // Use this for initialization
    void Start()
    {
        //        train = (GameObject.Find("PlayerTrain")).transform;
        GameManagerScript = FindObjectOfType<GameManagerScriptCoop>();
    }

    // Update is called once per frame
    void Update()
    {
        GamePadState currentState = GamePad.GetState(playerIndex);
 
            if (playerInstance == null)
            {
                if (GameManagerScript.player2AI)
                {
                    PlayerSpawnText.enabled = false;
                }

                else
                {
                    PlayerSpawnText.enabled = true;
                }
                //check to see if the player pushed the A button
                if (currentState.Buttons.A == ButtonState.Pressed && GameManagerScript.p2Spawnable && !GameManagerScript.player2AI)
                {
                    playerInstance = Instantiate(player, this.transform.position, this.transform.rotation) as GameObject;
                    playerInstance.GetComponent<playerControl>().playerIndex = playerIndex;
                    PlayerSpawnText.enabled = false;
                }
            }
        else
        {
            if (currentState.Buttons.Back == ButtonState.Pressed)
            {
                Destroy(playerInstance);
                return;
            }
            if (currentState.PacketNumber > lastPacketNumber)
            {
                lastPacketNumber = currentState.PacketNumber;
                lastPacketTime = Time.time;
            }
            else
            {
                if (Time.time - lastPacketTime > 10)
                {

                }
            }
        }
    }
}
