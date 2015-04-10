using UnityEngine;
using System.Collections;

public class shotProjectileScript : MonoBehaviour
{
    public int attackDamage;
    health Health;
    EnemyHealth EnemyHealth;
    CoreHealth CoreHealth;
    public float lifeTime;
    void Start () {
        lifeTime = 7F;
        }
	
	// Update is called once per frame
	void Update () {
        if (lifeTime >= 0)
        {
            lifeTime -= Time.deltaTime;
        }

        else if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
        AstarPath.active.UpdateGraphs(this.GetComponent<Collider2D>().bounds);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player1Shield" || coll.gameObject.tag == "Player2Shield")
        {
            Debug.Log("Did damage to " + coll.gameObject.tag + " with " + attackDamage + " points");
            Health = coll.gameObject.GetComponentInParent<health>();
            Health.TakeDamage(attackDamage, "Shield", this.gameObject.tag);
            Health.shieldRechargeTime = 3F;
            Destroy(this.gameObject);
            
        }
        else if (coll.gameObject.tag == "Player1" || coll.gameObject.tag == "Player2")
        {
            Health = coll.gameObject.GetComponentInParent<health>();
            Health.TakeDamage(attackDamage, "Player", this.gameObject.tag);
            Destroy(this.gameObject);
        }

        else if (coll.gameObject.tag == "Turret" && this.gameObject.tag != "TurretShot")
        {
            EnemyHealth = coll.gameObject.GetComponentInParent<EnemyHealth>();
            EnemyHealth.TakeDamage(attackDamage, "Enemy", this.gameObject.tag);
            Destroy(this.gameObject);
        }

        else if (coll.gameObject.tag == "EnemySeeker")
        {
            EnemyHealth = coll.gameObject.GetComponentInParent<EnemyHealth>();
            EnemyHealth.TakeDamage(attackDamage, "Enemy", this.gameObject.tag);
            Destroy(this.gameObject);
        }

        else if (coll.gameObject.tag == "CoreTarget" && this.gameObject.tag != "Player1Shot" && this.gameObject.tag != "Player2Shot" && this.gameObject.tag != "Player3Shot" && this.gameObject.tag != "Player4Shot")
        {
            CoreHealth = coll.gameObject.GetComponentInParent<CoreHealth>();
            CoreHealth.TakeDamage(attackDamage, "Enemy", this.gameObject.tag);
            Destroy(this.gameObject);
        }

        
    }


}
