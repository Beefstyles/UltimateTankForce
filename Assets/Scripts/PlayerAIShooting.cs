using UnityEngine;
using System.Collections;

public class PlayerAIShooting : MonoBehaviour 
{
    public bool targetAcquired;
    public bool targetAttackable;
    public GameObject target;
    LineRenderer targetRay;
    public GameObject targetEnemy;
    public GameObject targetShot;
    public bool targetShotNearby;
    public LineRenderer TargetRay
    {
        get { return targetRay; }
        set { targetRay = value; }
    }
    private Vector2 turretPos;
    public GameObject shootPoint;
    public Vector2 testRay2DVector;
    RaycastHit2D testRay2D;
    public GameObject projectile;
    private GameObject projectileClone;
    private float projectileForce = 2000F;
    private float fireRate;
    public Vector2 projectileDirectionHeading;
    public Vector2 targetingProjectileDirectionHeading;
    public float projectileDirectionMag;
    public float targetingProjectileDirectionMag;
    public Vector2 projectileDirection;
    public Vector2 targetingProjectileDirection;
    private Vector2 targetVelocity;
    private Vector3 headingVelocity;
    private Vector3 rotationDirection;
    AIControlScript AIControlScript;
    public GameObject shield;
    public bool shieldOff;
    public float shieldOffTimer;
    private bool targetAcquiredShot;

    public bool TargetAcquiredShot
    {
        get { return targetAcquiredShot; }
        set { targetAcquiredShot = value; }
    }

    int AILayerMask = 1 << 12;


    public int x, y;

    void Start()
    {
               AILayerMask = ~AILayerMask;
               fireRate = 1F;
               AIControlScript = GetComponent<AIControlScript>();
    }

    

    public void TargetLocater()
    {
        if (targetEnemy != null && targetShot == null)
        {
            headingVelocity = new Vector3(targetVelocity.x, targetVelocity.y, 0); 
            turretPos = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
           
        }
        else if (targetShot != null && targetShotNearby == true)
        {
            headingVelocity = new Vector3(targetVelocity.x, targetVelocity.y, 0);
            turretPos = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        }
      }
         
   

    void Update()
    {
        if (fireRate >= 0)
        {
            fireRate -= Time.deltaTime;
        }
        if (targetEnemy != null)
        {
            TargetLocater();
        }

        

        if (shieldOffTimer >= 0)
        {
            shieldOffTimer -= Time.deltaTime;
            if (shield.activeSelf)
            {
                shield.SetActive(false);
            }
        }

        else if (shieldOffTimer <= 0)
        {
            if (!shield.activeSelf)
            {
                shield.SetActive(true);
            }
        }
        if (targetAcquired || targetShotNearby)
        {
        
            if (targetShotNearby)
            {
                target = targetShot;
            }
            else if (!targetShotNearby && targetAcquired)
            {
                target = targetEnemy;
            }
            
                if (target != null)
                {
                    projectileDirectionHeading = (target.transform.position) - this.transform.position;
                    projectileDirectionMag = projectileDirectionHeading.magnitude;
                    projectileDirection = projectileDirectionHeading / projectileDirectionMag;
                    rotationDirection = this.transform.position - target.transform.position;
                    if (!targetShotNearby && targetAcquired)
                    {
                        targetingProjectileDirectionHeading = (targetEnemy.transform.position) - this.transform.position;
                        targetingProjectileDirectionMag = targetingProjectileDirectionHeading.magnitude;
                        targetingProjectileDirection = targetingProjectileDirectionHeading / projectileDirectionMag;
                        testRay2DVector = new Vector2(targetEnemy.transform.position.x, targetEnemy.transform.position.y);
                        //testRay2D = Physics2D.Raycast(shootPoint.transform.position, targetingProjectileDirection, Mathf.Infinity, AILayerMask);
                        testRay2D = Physics2D.Linecast(shootPoint.transform.position, targetEnemy.transform.position, AILayerMask);

                        if (testRay2D != null)
                        {
                            Debug.DrawLine(shootPoint.transform.position, testRay2D.transform.position);
                            //Debug.Log("Linecast gives this " + testRay2D.collider.GetComponent<Collider2D>().tag);
                            if (testRay2D.collider.tag == "Player1" || testRay2D.collider.tag == "Player2" || testRay2D.collider.tag == "Player3" || testRay2D.collider.tag == "Player4" || testRay2D.collider.tag == "Player1Shield" || testRay2D.collider.tag == "Player2Shield" || testRay2D.collider.tag == "Player3Shield" || testRay2D.collider.tag == "Player4Shield")
                            {
                                targetAttackable = true;
                            }
                            else
                            {
                                targetAttackable = false;
                            }
                        }

                        else
                        {
                            targetAttackable = false;
                        }
                    }
                   
                }      
            if (rotationDirection.x != 0.0F || rotationDirection.y != 0.0F)
            {
                float angle = Mathf.Atan2(-rotationDirection.y, -rotationDirection.x) * Mathf.Rad2Deg;
                AIControlScript.body.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            if (fireRate <= 0 && !targetShotNearby && targetAttackable)
            {
                Shoot();
            }
    }
        
    }

   
    void Shoot()
    {
        shieldOffTimer = 1F;
        projectileClone = Instantiate(projectile, shootPoint.transform.position, Quaternion.identity) as GameObject;
        switch (this.gameObject.tag)
        {
            case("Player1"):
                projectileClone.gameObject.tag = "Player1Shot";
                break;
            case ("Player2"):
                projectileClone.gameObject.tag = "Player2Shot";
                break;
            case ("Player3"):
                projectileClone.gameObject.tag = "Player3Shot";
                break;
            case ("Player4"):
                projectileClone.gameObject.tag = "Player4Shot";
                break;
        }
        projectileClone.GetComponent<Rigidbody2D>().isKinematic = false;
        projectileClone.GetComponent<Rigidbody2D>().AddForce(projectileDirection * projectileForce);
        fireRate = 1F;
    }

}

