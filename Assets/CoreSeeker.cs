using UnityEngine;
using System.Collections;

public class CoreSeeker : MonoBehaviour {

    public Transform target;
    public float speed = 250F;
    CoreHealth CoreHealth;
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
        CoreHealth = coll.gameObject.GetComponentInParent<CoreHealth>();
        CoreHealth.TakeDamage(attackDamage, "Enemy", this.gameObject.tag);
        Destroy(this.gameObject);
    }
}
