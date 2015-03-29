using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {


    public int Health = 5;
    public int currentHealth;
    private bool Dead;
    public GameObject TurretDead;
    public GameObject turretChar;
    private GameObject enemyDead;
    public float shieldRechargeTime = 3F;
    GameManagerScript GameManager;

    void Awake()
    {
        currentHealth = Health;
       
        GameManager = GetComponent<GameManagerScript>();
    }

    void Update()
    {

    }

    public void TakeDamage(int amount, string target)
    {
        if (target == "Enemy")
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                 StartCoroutine("ShieldDeath");
            }
        }
                
    }

   

    IEnumerator EnemyDeath()
    {
        if (this.gameObject.tag == "Player1")
        {
            enemyDead = Instantiate(TurretDead, turretChar.transform.position, turretChar.transform.rotation) as GameObject;
        }
        Destroy(this.gameObject);
        yield return new WaitForSeconds(1F);
    }

	
}
