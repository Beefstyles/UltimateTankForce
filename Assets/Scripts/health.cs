using UnityEngine;
using System.Collections;

public class health : MonoBehaviour {


    public int shieldHealth = 5;
    public int currentShieldHealth;
    public int playerHealth;
    public int currentPlayerHealth;
    private bool shieldIsDestroyed;
    private bool playerDead;
    public GameObject playerShield;
    public GameObject playerChar;
    public GameObject playerDeadCorpse;
    private GameObject playerCharDead;
    private SpriteRenderer playerShieldSprite;
    private Color fullShield = new Color (1F, 1F, 1F, 1F);
    private Color fourthShield = new Color(1F, 1F, 1F, .8F);
    private Color thirdShield = new Color(1F, 1F, 1F, .6F);
    private Color secondShield = new Color(1F, 1F, 1F, .4F);
    private Color firstShield = new Color(1F, 1F, 1F, .2F);
    private Color noShield = new Color(1F, 1F, 1F, 0F);
    public GameObject playerShieldCollider;
    public float shieldRechargeTime = 3F;
    GameManagerScript GameManager;
    playerControl playerControl;


    void Awake()
    {
        currentShieldHealth = shieldHealth;
        currentPlayerHealth = playerHealth;
        playerShieldSprite = playerShield.GetComponentInChildren<SpriteRenderer>();
        GameManager = FindObjectOfType<GameManagerScript>();
        playerControl = GetComponentInParent<playerControl>();
       
    }

    void Update()
    {
        switch (currentShieldHealth)
        {
            case 5:
            playerShieldSprite.color = fullShield;
            break;
            case 4:
            playerShieldSprite.color = fourthShield;
            break;
            case 3:
            playerShieldSprite.color = thirdShield;
            break;
            case 2:
            playerShieldSprite.color = secondShield;
            break;
            case 1:
            playerShieldSprite.color = firstShield;
            break;
            case 0:
            playerShieldSprite.color = noShield;
            break;
        }

        if (shieldIsDestroyed)
        {
            if (playerShieldCollider.activeSelf)
            {
                playerShieldCollider.SetActive(false);
            }
        }

        else if (!shieldIsDestroyed)
        {
            if (!playerShieldCollider.activeSelf)
            {
                playerShieldCollider.SetActive(true);
            }
        }

        if (shieldRechargeTime >= 0)
        {
            shieldRechargeTime -= Time.deltaTime;
        }
        

        if (shieldRechargeTime <= 0 && currentShieldHealth < shieldHealth)
        {
            currentShieldHealth++;
            shieldRechargeTime = 3F;
        }

    }

    public void TakeDamage(int amount, string target, string Originator)
    {
        if (target == "Shield")
        {
            currentShieldHealth -= amount;
           
            if (currentShieldHealth <= 0 && !shieldIsDestroyed)
            {
                shieldIsDestroyed = true;
                StartCoroutine("ShieldDeath");
            }
        }
        else if (target == "Player")
        {
            currentPlayerHealth -= amount;
            if (currentPlayerHealth <= 0 && !playerDead)
            {
                playerDead = true;
                if (Originator == "Player1Shot")
                {
                    switch (this.gameObject.tag)
                    {
                       case("Player1"):
                       GameManager.p1deaths++;
                       break;
                       case ("Player2"):
                       GameManager.p1kills++;
                       GameManager.p2deaths++;
                       break;
                       case ("Player3"):
                       GameManager.p1kills++;
                       GameManager.p3deaths++;
                       break;
                       case ("Player4"):
                       GameManager.p1kills++;
                       GameManager.p4deaths++;
                       break;
                    }
                    
                }
                else if (Originator == "Player2Shot")
                {
                    switch (this.gameObject.tag)
                    {
                        case ("Player1"):
                            GameManager.p2kills++;
                            GameManager.p1deaths++;
                            break;
                        case ("Player2"):
                            GameManager.p2deaths++;
                            break;
                        case ("Player3"):
                            GameManager.p2kills++;
                            GameManager.p3deaths++;
                            break;
                        case ("Player4"):
                            GameManager.p2kills++;
                            GameManager.p4deaths++;
                            break;
                    }
                }

                else if (Originator == "Player3Shot")
                {
                    switch (this.gameObject.tag)
                    {
                        case ("Player1"):
                            GameManager.p3kills++;
                            GameManager.p1deaths++;
                            break;
                        case ("Player2"):
                            GameManager.p3kills++;
                            GameManager.p2deaths++;
                            break;
                        case ("Player3"):
                            GameManager.p3deaths++;
                            break;
                        case ("Player4"):
                            GameManager.p3kills++;
                            GameManager.p4deaths++;
                            break;
                    }
                }

                else if (Originator == "Player4Shot")
                {
                    switch (this.gameObject.tag)
                    {
                        case ("Player1"):
                            GameManager.p4kills++;
                            GameManager.p1deaths++;
                            break;
                        case ("Player2"):
                            GameManager.p4kills++;
                            GameManager.p2deaths++;
                            break;
                        case ("Player3"):
                            GameManager.p4kills++;
                            GameManager.p3deaths++;
                            break;
                        case ("Player4"):
                            GameManager.p4deaths++;
                            break;
                    }
                }

                StartCoroutine("PlayerDeath");
            }
        }
        
    }

    IEnumerator ShieldDeath()
    {
        yield return new WaitForSeconds(3F);
        currentShieldHealth = shieldHealth;
        shieldIsDestroyed = false;
    }

    IEnumerator PlayerDeath()
    {
        //playerControl.VibrateController(0.5F);
        if (this.gameObject.tag == "Player1" || this.gameObject.tag == "Player2" || this.gameObject.tag == "Player3" || this.gameObject.tag == "Player4")
        {
            playerCharDead = Instantiate(playerDeadCorpse, playerChar.transform.position, playerChar.transform.rotation) as GameObject;
        }
        yield return new WaitForSeconds(0.2F);
        switch (this.gameObject.tag)
        {
            case("Player1"):
            GameManager.p1Alive = false;
            GameManager.p1SpawnTimer = 1F;
                break;
            case ("Player2"):
                GameManager.p2Alive = false;
                GameManager.p2SpawnTimer = 1F;
                break;
            case ("Player3"):
                GameManager.p3Alive = false;
                GameManager.p3SpawnTimer = 1F;
                break;
            case ("Player4"):
                GameManager.p4Alive = false;
                GameManager.p4SpawnTimer = 1F;
                break;
        }
        Destroy(this.gameObject);
    }

	
}
