using UnityEngine;
using System.Collections;
using Pathfinding;

public class AIControlScript : MonoBehaviour {

    public Vector3 targetPositionVector;
    public GameObject targetPosition;

	// Use this for initialization
	void Start () {
        Seeker seeker = GetComponent<Seeker>();
        targetPositionVector = targetPosition.transform.position;
        seeker.StartPath(transform.position, targetPositionVector, OnPathComplete);
	}
	
    public void OnPathComplete (Path p) {
        Debug.Log ("Yay, we got a path back. Did it have an error? "+p.error);
    }
}
