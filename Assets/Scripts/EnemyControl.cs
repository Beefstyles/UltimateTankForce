using UnityEngine;
using System.Collections;
using XInputDotNetPure;


public class EnemyControl : MonoBehaviour
{
    public bool targetAcquired;
    public bool targetAttackable;
    public GameObject target;
    
    LineRenderer targetRay;
    private Vector2 turretPos;
    Vector2 testRay2D;
    RaycastHit2D[] testRay;
    public GameObject projectile;
    private GameObject projectileClone;
    private float projectileForce = 4000F;
    private float fireRate;
    public Vector2 projectileDirectionHeading;
    public float projectileDirectionMag;
    public Vector2 projectileDirection;
    private Vector2 targetVelocity;
    private Vector3 headingVelocity;
    GameManagerScript GameManager;
    playerControl controlScript;
    public int x, y;
    private string AITargetString;

    void Start()
    {
               fireRate = 1F;
               targetRay = GetComponent<LineRenderer>();
               AITargetString = "CoreTarget";

         }

    void OnTriggerStay2D(Collider2D targetColl)
    {
       if (targetColl.gameObject.tag == AITargetString)
        {
            targetAcquired = true;
            if (targetColl.gameObject != null)
            {
                controlScript = targetColl.gameObject.GetComponentInParent<playerControl>();
                if (controlScript != null)
                {
                    targetVelocity = controlScript.objectVelocity;
                    headingVelocity = new Vector3(targetVelocity.x, targetVelocity.y, 0);
                }
                                
                target = targetColl.gameObject;
                turretPos = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
                testRay2D = new Vector2 (target.transform.position.x, target.transform.position.y);
                testRay = Physics2D.RaycastAll(turretPos, testRay2D, Mathf.Infinity);
                targetAttackable = true;
                if (testRay[0].transform != null)
                {
                   foreach (RaycastHit2D objectHit in testRay)
                    {
                        
                    }
                   }
                }              
              
            } 
                 
        }  
    

    void OnTriggerExit2D(Collider2D targetColl)
    {
        if (targetColl.gameObject.tag == AITargetString)
        {
            if (targetRay.enabled)
            {
                targetRay.enabled = false;
            }
            targetAttackable = false;
            targetAcquired = false;
           }
     }

    void Update()
    {
        if (fireRate >= 0)
        {
            fireRate -= Time.deltaTime;
        }

        if (fireRate <= 0 && targetAcquired == true && target != null && targetAttackable == true)
        {
            projectileDirectionHeading = (target.transform.position) - this.transform.position;
            projectileDirectionMag = projectileDirectionHeading.magnitude;
            projectileDirection = projectileDirectionHeading / projectileDirectionMag;
            Shoot();
        }
    }

   
    void Shoot()
    {
        StartCoroutine("targetLine");
        projectileClone = Instantiate(projectile, this.transform.position, Quaternion.identity) as GameObject;
        projectileClone.transform.parent = this.transform;
        projectileClone.gameObject.tag = "EnemyShot";
        projectileClone.GetComponent<Rigidbody2D>().isKinematic = false;
        projectileClone.GetComponent<Rigidbody2D>().AddForce(projectileDirection * projectileForce);
        fireRate = 3F;
    }

    IEnumerator targetLine()
    {
        targetRay.enabled = true;
        targetRay.SetPosition(0, this.transform.position);
        targetRay.SetPosition(1, target.transform.position);
        yield return new WaitForSeconds(1F);
        targetRay.enabled = false;
    }
}


