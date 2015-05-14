using UnityEngine;
using System.Collections;

public class CoreSeeker : MonoBehaviour {

    public Transform target;
    public float speed = 250F;
    CoreHealth CoreHealth;
    health Health;
    public int attackDamage = 1;

	// Use this for initialization
	void Start () {
	
	}
	

	void Update () {
        Vector3 dir = (target.position - this.transform.position).normalized;
        dir *= speed * Time.deltaTime;
        transform.Translate(dir);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "CoreTarget")
        {
            CoreHealth = coll.gameObject.GetComponentInParent<CoreHealth>();
            CoreHealth.TakeDamage(attackDamage, "Enemy", this.gameObject.tag);
            Destroy(this.gameObject);
        }
        else if (coll.gameObject.tag == "Player1Shield" || coll.gameObject.tag == "Player2Shield" || coll.gameObject.tag == "Player3Shield" || coll.gameObject.tag == "Player4Shield")
        {
            //  Debug.Log("Did damage to " + coll.gameObject.tag + " with " + attackDamage + " points");
            Health = coll.gameObject.GetComponentInParent<health>();
            Health.TakeDamage(attackDamage, "Shield", this.gameObject.tag);
            Health.shieldRechargeTime = 3F;
            Destroy(this.gameObject);
        }
        else if (coll.gameObject.tag == "Player1" || coll.gameObject.tag == "Player2" || coll.gameObject.tag == "Player3" || coll.gameObject.tag == "Player4")
        {
            Health = coll.gameObject.GetComponentInParent<health>();
            Health.TakeDamage(attackDamage, "Player", this.gameObject.tag);
            Destroy(this.gameObject);
        }
        
    }
}
