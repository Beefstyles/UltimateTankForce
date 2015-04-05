using UnityEngine;
using System.Collections;

public class rotateObject : MonoBehaviour {

    private GameObject RotationObject;
    private float rotationSpeed = 25F; 

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed, Space.World);
	}
}
