using UnityEngine;
using System.Collections;
using Pathfinding;

public class AIControlScript : MonoBehaviour {

    //Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
    //This line should always be present at the top of scripts which use pathfinding

    //The point to move to
    public Vector3 targetPosition;
    public GameObject AITargetGO;
    private Seeker seeker;
    //private CharacterController controller;

    //The calculated path
    public Path path;

    //The AI's speed per second
    public float speed = 250F;


    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    //public GameObject target;



    public void Start()
    {
        targetPosition = AITargetGO.transform.position;
        seeker = GetComponent<Seeker>();
        StartCoroutine(AITarget("Home"));
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
       
    }

   IEnumerator AITarget(string target)
    {
        if (target == "Ball")
        {
            targetPosition = this.transform.position;
            Path pNew = seeker.GetNewPath(transform.position, targetPosition);
            seeker.StartPath(pNew, OnPathComplete);

        }
        if (target == "Home")
        {
                Path pNew = seeker.GetNewPath(transform.position, targetPosition);
                seeker.StartPath(pNew, OnPathComplete); 
            }
        yield return new WaitForSeconds(1F);
    }
    public void OnPathComplete(Path p)
    {
        //Debug.Log ("Yay, we got a path back. Did it have an error? "+p.error);
        if (!p.error)
        {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
            return;

        }
    }



    public void Update()
    {

        if (path == null)
        {
            //We have no path to move after yet
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            //Debug.Log ("End Of Path Reached");
           
            return;
        }


        if (currentWaypoint == path.vectorPath.Count)
        {
            currentWaypoint++;
            //Debug.Log ("End Of Path Reached");
            return;
        }

        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.deltaTime;
        transform.Translate(dir);


        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }

            }
        }


