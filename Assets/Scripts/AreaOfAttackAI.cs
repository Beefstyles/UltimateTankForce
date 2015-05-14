using UnityEngine;
using System.Collections;

public class AreaOfAttackAI : MonoBehaviour
{
    PlayerAIShooting PlayerAIShooting;

    private bool targetAcquiredShot;
    private string attackTarget0;

    public string AttackTarget0
    {
        get { return attackTarget0; }
        set { attackTarget0 = value; }
    }
    private string attackTarget1;

    public string AttackTarget1
    {
        get { return attackTarget1; }
        set { attackTarget1 = value; }
    }
    private string attackTarget2;

    public string AttackTarget2
    {
        get { return attackTarget2; }
        set { attackTarget2 = value; }
    }
    private string attackTarget3;

    public string AttackTarget3
    {
        get { return attackTarget3; }
        set { attackTarget3 = value; }
    }

    private float targetResetTimer;

   
    void Start()
    {
        PlayerAIShooting = GetComponentInParent<PlayerAIShooting>();
        attackTarget0 = "Player1";
        attackTarget1 = "Player2";
        attackTarget2 = "Player3";
        attackTarget3 = "Player4";
        
    }

    void OnTriggerEnter2D(Collider2D targetColl)
    {

        if (targetColl.gameObject.tag == attackTarget0 || targetColl.gameObject.tag == attackTarget1 || targetColl.gameObject.tag == attackTarget2 || targetColl.gameObject.tag == attackTarget3)
        {
            //Debug.Log("Something entered called " + targetColl.name.ToString());
            PlayerAIShooting.TargetAcquiredShot = true;
        }
    }
    void OnTriggerStay2D(Collider2D targetColl)
    {
        if (targetColl.gameObject.tag == attackTarget0 || targetColl.gameObject.tag == attackTarget1 || targetColl.gameObject.tag == attackTarget2 || targetColl.gameObject.tag == attackTarget3)
        {

            // Debug.Log("Something is staying called " + targetColl.name.ToString());
            if (targetColl.gameObject != null)
            {
                PlayerAIShooting.targetEnemy = targetColl.gameObject;
                PlayerAIShooting.targetAcquired = true;            
                //Debug.Log("Target called " + targetColl.gameObject.tag);
            }

            else if (targetColl.gameObject == null)
            {
                PlayerAIShooting.targetEnemy = null;
                PlayerAIShooting.targetAcquired = false;
            }
                }
            }

    void OnTriggerExit2D(Collider2D targetColl)
    {
        if (targetColl.gameObject.tag == attackTarget0 || targetColl.gameObject.tag == attackTarget1 || targetColl.gameObject.tag == attackTarget2 || targetColl.gameObject.tag == attackTarget3)
        {
            PlayerAIShooting.targetEnemy = null;
            PlayerAIShooting.targetAcquired = false;
            //Debug.Log("Something left called " + targetColl.name.ToString());
            PlayerAIShooting.targetAttackable = false;

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
            PlayerAIShooting.targetEnemy = null;
            PlayerAIShooting.targetAcquired = false;
            targetResetTimer = 1F;
        }

    }
}
