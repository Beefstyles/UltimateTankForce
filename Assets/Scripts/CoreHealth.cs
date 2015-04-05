using UnityEngine;
using System.Collections;

public class CoreHealth : MonoBehaviour {

    private int coreHealth = 5;
    public int currentCoreHealth;
     public GameObject playerChar;
    public GameObject coreDead;
    public GameObject coreDeadGO;
    private GameObject playerCharDead;
    private SpriteRenderer coreShieldSprite;
    public Sprite fullShield, fourthShield, thirdShield, secondShield, firstShield, noShield, coreBroken;
    public GameObject playerShieldCollider;
    public float shieldRechargeTime = 3F;
    GameManagerScript GameManager;
    playerControl playerControl;


    void Awake()
    {
        currentCoreHealth = coreHealth;
        coreShieldSprite = GetComponent<SpriteRenderer>();
        GameManager = FindObjectOfType<GameManagerScript>();
    }

    void Update()
    {
        switch (currentCoreHealth)
        {
            case 5:
            coreShieldSprite.sprite = fullShield;
            break;
            case 4:
            coreShieldSprite.sprite = fourthShield;
            break;
            case 3:
            coreShieldSprite.sprite = thirdShield;
            break;
            case 2:
            coreShieldSprite.sprite = secondShield;
            break;
            case 1:
            coreShieldSprite.sprite = firstShield;
            break;
            case 0:
            coreShieldSprite.sprite = noShield;
            break;
        }

        

        if (shieldRechargeTime <= 0)
        {
            shieldRechargeTime -= Time.deltaTime;
        }


        if (shieldRechargeTime <= 0 && currentCoreHealth < coreHealth)
        {
            currentCoreHealth++;
        }

    }

    public void TakeDamage(int amount, string target, string Originator)
    {
            currentCoreHealth -= amount;
            if (currentCoreHealth <= 0)
            {
                StartCoroutine("CoreDeath");
            }
    }



    IEnumerator CoreDeath()
    {
        coreDead = Instantiate(coreDeadGO, this.transform.position, this.transform.rotation) as GameObject;
        Destroy(this.gameObject);
        yield return new WaitForSeconds(0.2F);
    }

	
}
