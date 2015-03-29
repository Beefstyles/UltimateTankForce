using UnityEngine;
using System.Collections;
using XInputDotNetPure;


public class playerControl : MonoBehaviour
{
    public Boundary boundary;
    private float speed = 250F;
    public float h;
    public float v;
    public float angH;
    public float angV;
    private float angle;
    private float angle2;
    public GameObject projectile;
    public GameObject shootPoint;
    private GameObject projectileClone;
    private float projectileForce = 2000F;
    bool playerIndexSet = false;
    public PlayerIndex playerIndex;
    GamePadState previousState;
    GamePadState currentState;
    private float fireRate;
    public Vector2 projectileDirectionHeading;
    public float projectileDirectionMag;
    public Vector2 projectileDirection;
    public bool shieldOff;
    private float shieldOffTimer;
    public GameObject shield;
    private LineRenderer shootLine;
    GameManagerScript GameManager;
    public Vector2 testVelocity;
    public GameObject projectileShotLoc;
    private AudioClip projectileShotAudio;
   


    

    void Start()
    {
               GameManager = GetComponent<GameManagerScript>();
               fireRate = 1F;
               GamePad.SetVibration(playerIndex, 0, 0);
               projectileShotAudio = projectileShotLoc.GetComponent<AudioClip>();
    }

    void Update()
    {
        HandleXInput();
        
        if (fireRate >= 0)
        {
            fireRate -= Time.deltaTime;
        }

            shieldOffTimer -= Time.deltaTime;

            if (shieldOffTimer >= 0)
        {
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

     
    }

    void HandleXInput()
    {
        currentState = GamePad.GetState(playerIndex);

        if (!currentState.IsConnected)
        {
            return;
        }

        h = currentState.ThumbSticks.Left.X;
        v = currentState.ThumbSticks.Left.Y;
        angV = currentState.ThumbSticks.Right.X;
        angH = currentState.ThumbSticks.Right.Y;

        if (currentState.Triggers.Right == 1 && fireRate <= 0)
        {
            projectileDirectionHeading = shield.transform.position - this.transform.position;
            projectileDirectionMag = projectileDirectionHeading.magnitude;
            projectileDirection = projectileDirectionHeading / projectileDirectionMag;
            shieldOffTimer = 1F;
            Shoot();
        }

        previousState = currentState;
    }

    public void VibrateController(float time)
    {
        GamePad.SetVibration(playerIndex, 1, 1);
        do
        {
            time -= Time.deltaTime;
        }
        while (time >= 0);
        GamePad.SetVibration(playerIndex, 0, 0);     
    }

    void Shoot()
    {
        projectileClone = Instantiate(projectile, shootPoint.transform.position, Quaternion.identity) as GameObject;
        //AudioSource.PlayClipAtPoint(projectileShotAudio, shootPoint.transform.position);
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

    void FixedUpdate()
    {
       
        Vector2 movement = new Vector2(h, v);
        GetComponent<Rigidbody2D>().velocity = movement * speed;
        if (angH != 0.0F || angV != 0.0)
        {
            angle = Mathf.Atan2(angV, angH) * Mathf.Rad2Deg;
            angle2 = 90F - angle;
            transform.rotation = Quaternion.AngleAxis(angle2, Vector3.forward);
        }

        /*GetComponent<Rigidbody2D>().position = new Vector2
        (
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax));*/
    }
}



