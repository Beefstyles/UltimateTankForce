﻿using UnityEngine;
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
    private float speed = 80F;


    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    //public GameObject target;

    private Vector3 dir; 
    public Vector3 rotationDirection;
    public GameObject body;
    PlayerAIShooting PlayerAIShooting;
    AITargets[] AITargets;

    public void Start()
    {
        AITargets = FindObjectsOfType<AITargets>();

        seeker = GetComponent<Seeker>();
        StartCoroutine(AITarget("Home"));
        PlayerAIShooting = GetComponent<PlayerAIShooting>();
    }


   IEnumerator AITarget(string target)
    {
        if (target == "Home")
        {
            AITargets thisAiTarget = AITargets[Random.Range(0, AITargets.Length)];
            targetPosition = thisAiTarget.transform.position;
            Path pNew = seeker.GetNewPath(transform.position, targetPosition);
            seeker.StartPath(pNew, OnPathComplete);  
            }
        yield return new WaitForSeconds(1F);
    }
    public void OnPathComplete(Path p)
    {
        //StartCoroutine(AITarget("Home"));
        //Debug.Log ("Yay, we got a path back. Did it have an error? "+p.error);
        //if (targetPosition != AITargetGO.transform.position)
        //{
            
            
        //}
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
            StartCoroutine(AITarget("Home"));
            Debug.Log ("End Of Path Reached");
            //if (targetPosition != AITargetGO.transform.position)
            //{
                //AITargets thisAiTarget = AITargets[Random.Range(0, AITargets.Length)];
                //targetPosition = thisAiTarget.transform.position;
                
            //}
            return;
        }


        if (currentWaypoint == path.vectorPath.Count)
        {
            currentWaypoint++;
            StartCoroutine(AITarget("Home"));
            Debug.Log ("End Of Path Reached");
            return;
        }

        //Direction to the next waypoint
        dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.deltaTime;

        rotationDirection = this.transform.position - targetPosition;
        if (PlayerAIShooting.targetAcquired != true)
        {
            if (rotationDirection.x != 0.0F || rotationDirection.y != 0.0F)
            {
                float angle = Mathf.Atan2(-rotationDirection.y, -rotationDirection.x) * Mathf.Rad2Deg;
                body.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        

        transform.Translate(dir);


        //if (targetPosition != AITargetGO.transform.position)
        //{
        //    AITargets thisAiTarget = AITargets[Random.Range(0, AITargets.Length)];
        //    targetPosition = thisAiTarget.transform.position;
        //    StartCoroutine(AITarget("Home"));
        //}
        
       


        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }

            }
        }


