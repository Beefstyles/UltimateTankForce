using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {


    public int Health = 5;
    public int currentHealth;
    private bool Dead;
    public GameObject TurretDead;

    private Color fullHealth = new Color(1F, 1F, 1F, 1F);
    private Color fourthHealth = new Color(1F, 1F, 1F, .95F);
    private Color thirdHealth = new Color(1F, 1F, 1F, .9F);
    private Color secondHealth = new Color(1F, 1F, 1F, .85F);
    private Color firstHealth= new Color(1F, 1F, 1F, .8F);
    
    private SpriteRenderer enemySprite;
    private GameObject enemyDead;
    public float shieldRechargeTime = 3F;

    void Awake()
    {
        currentHealth = Health;
        enemySprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        switch (currentHealth)
        {
            case 5:
                enemySprite.color = fullHealth;
                break;
            case 4:
                enemySprite.color = fourthHealth;
                break;
            case 3:
                enemySprite.color = thirdHealth;
                break;
            case 2:
                enemySprite.color = secondHealth;
                break;
            case 1:
                enemySprite.color = firstHealth;
                break;
        }
    }

    public void TakeDamage(int amount, string target, string Originator)
    {
        if (target == "Enemy")
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                StartCoroutine("EnemyDeath");
            }
        }
                
    }

   

    IEnumerator EnemyDeath()
    {
        enemyDead = Instantiate(TurretDead, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
        yield return new WaitForSeconds(0.1F);
        Destroy(this.gameObject);
    }

	
}
