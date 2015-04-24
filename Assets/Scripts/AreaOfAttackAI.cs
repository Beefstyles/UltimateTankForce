using UnityEngine;
using System.Collections;

public class AreaOfAttackAI : MonoBehaviour
{
    PlayerAIShooting PlayerAIShooting;

    private bool targetAcquiredShot;
    private string attackTarget;

    public string AttackTarget
    {
        get { return attackTarget; }
        set { attackTarget = value; }
    }
    void Start()
    {
        PlayerAIShooting = GetComponentInParent<PlayerAIShooting>();
        attackTarget = "Player1";
    }

    void OnTriggerEnter2D(Collider2D targetColl)
    {
        if (targetColl.gameObject.tag == attackTarget)
        {
            Debug.Log("Something entered called " + targetColl.name.ToString());
            PlayerAIShooting.TargetAcquiredShot = true;
        }
    }
    void OnTriggerStay2D(Collider2D targetColl)
    {
       if (targetColl.gameObject.tag == "Player1")
        {
            
            // Debug.Log("Something is staying called " + targetColl.name.ToString());
            if (targetColl.gameObject != null)
            {
                PlayerAIShooting.targetEnemy = targetColl.gameObject;
                PlayerAIShooting.targetAcquired = true;            
                //Debug.Log("Target called " + targetColl.gameObject.tag);
            }
                }
            }

    void OnTriggerExit2D(Collider2D targetColl)
    {
        if (targetColl.gameObject.tag == "Player1")
        {
            PlayerAIShooting.targetEnemy = null;
            PlayerAIShooting.targetAcquired = false;
            //Debug.Log("Something left called " + targetColl.name.ToString());
            PlayerAIShooting.targetAttackable = false;

        }
    }

}
