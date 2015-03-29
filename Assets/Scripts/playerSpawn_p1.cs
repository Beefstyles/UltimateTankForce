using UnityEngine;
using System.Collections;
using XInputDotNetPure;
using UnityEngine.UI;

public class playerSpawn_p1 : MonoBehaviour
{
    public PlayerIndex playerIndex;
    public GameObject player1;
    public GameObject playerInstance;
    uint lastPacketNumber;
    float lastPacketTime;
    public Text PlayerSpawnText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GamePadState currentState = GamePad.GetState(playerIndex);

        if (playerInstance == null)
        {

            if (playerInstance == null)
            {
                PlayerSpawnText.enabled = true;
                //check to see if the player pushed the A button
                if (currentState.Buttons.A == ButtonState.Pressed)
                {
                    playerInstance = Instantiate(player1, this.transform.position, this.transform.rotation) as GameObject;
                    playerInstance.GetComponent<playerControl>().playerIndex = playerIndex;
                    PlayerSpawnText.enabled = false;
                }
            }
                    }
        else
        {
            //if (currentState.Buttons.Back == ButtonState.Pressed)
            //{
            //    Destroy(playerInstance);
            //    return;
            //}
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
