using UnityEngine;
using System.Collections;
using XInputDotNetPure;


public class EnemyControl : MonoBehaviour
{
    public bool targetAcquired;
    public GameObject target;
    LineRenderer targetRay;
    public GameObject projectile;
    private GameObject projectileClone;
    private float projectileForce = 2000F;
    private float fireRate;
    public Vector2 projectileDirectionHeading;
    public float projectileDirectionMag;
    public Vector2 projectileDirection;
    GameManagerScript GameManager;

    
    
    void Start()
    {
               GameManager = GetComponent<GameManagerScript>();
               fireRate = 1F;
               targetRay = GetComponent<LineRenderer>();


    }

    void OnTriggerStay2D(Collider2D targetColl)
    {
        if (targetColl.gameObject.tag == "Player1")
        {
            if (!targetRay.enabled)
            {
                targetRay.enabled = true;
            }
            targetAcquired = true;
            if (targetColl.gameObject != null)
            {
                target = targetColl.gameObject;
            } 
        }  
    }

    void OnTriggerExit2D(Collider2D targetColl)
    {
        if (targetColl.gameObject.tag == "Player1")
        {
            if (targetRay.enabled)
            {
                targetRay.enabled = false;
            }
            targetAcquired = false;
           }
     }

    void Update()
    {
        if (fireRate >= 0)
        {
            fireRate -= Time.deltaTime;
        }

        if (fireRate <= 0 && targetAcquired == true && target != null)
        {
            projectileDirectionHeading = target.transform.position - this.transform.position;
            projectileDirectionMag = projectileDirectionHeading.magnitude;
            projectileDirection = projectileDirectionHeading / projectileDirectionMag;
            Shoot();
        }
    }

   
    void Shoot()
    {
        targetRay.SetPosition(0, this.transform.position);
        targetRay.SetPosition(1, target.transform.position);
        projectileClone = Instantiate(projectile, this.transform.position, Quaternion.identity) as GameObject;
        projectileClone.GetComponent<Rigidbody2D>().isKinematic = false;
        projectileClone.GetComponent<Rigidbody2D>().AddForce(projectileDirection * projectileForce);
        fireRate = 3F;
    }
}


