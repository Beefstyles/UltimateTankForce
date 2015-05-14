using UnityEngine;
using System.Collections;

public class AreaOfDefenseAI : MonoBehaviour
{
    PlayerAIShooting PlayerAIShooting;
    private float targetResetTimer;
    private bool targetAcquiredShot;
    void Start()
    {
        targetResetTimer = 1F;
        PlayerAIShooting = GetComponentInParent<PlayerAIShooting>();
    }

    void OnTriggerEnter2D(Collider2D targetColl)
    {
        if (targetColl.gameObject.tag == "Player1Shot" || targetColl.gameObject.tag == "Player2Shot" || targetColl.gameObject.tag == "Player3Shot" || targetColl.gameObject.tag == "Player4Shot" || targetColl.gameObject.tag == "EnemyShot")
        {
            PlayerAIShooting.targetShotNearby = true;
        }
    }
    void OnTriggerStay2D(Collider2D targetColl)
    {
        if (targetColl.gameObject.tag == "Player1Shot" || targetColl.gameObject.tag == "Player2Shot" || targetColl.gameObject.tag == "Player3Shot" || targetColl.gameObject.tag == "Player4Shot" || targetColl.gameObject.tag == "EnemyShot")
        {
            // Debug.Log("Something is staying called " + targetColl.name.ToString());
            if (targetColl.gameObject != null)
            {
                PlayerAIShooting.targetShot = targetColl.gameObject;
                PlayerAIShooting.targetShotNearby = true;
                //Debug.Log("Target called " + targetColl.gameObject.tag);
            }
            if (targetColl.gameObject == null)
            {
                PlayerAIShooting.targetShot = null;
                PlayerAIShooting.targetShotNearby = false;
            }
                }
            }

    void OnTriggerExit2D(Collider2D targetColl)
    {
        if (targetColl.gameObject.tag == "Player1Shot" || targetColl.gameObject.tag == "Player2Shot" || targetColl.gameObject.tag == "Player3Shot" || targetColl.gameObject.tag == "Player4Shot" || targetColl.gameObject.tag == "EnemyShot")
        {
            PlayerAIShooting.targetShot = null;
            PlayerAIShooting.targetShotNearby = false;
            //Debug.Log("Something left called " + targetColl.name.ToString());

        }
    }

    void Update()
    {
        if (targetResetTimer >= 0)
        {
            targetResetTimer -= Time.deltaTime;
        }

        else if (targetResetTimer <= 0)
        {
            PlayerAIShooting.targetShot = null;
            PlayerAIShooting.targetShotNearby = false;
            targetResetTimer = 1F;
        }
        
    }
}
