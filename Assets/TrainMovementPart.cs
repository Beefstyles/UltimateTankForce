using UnityEngine;
using System.Collections;

public class TrainMovementPart : MonoBehaviour {

    trainMovement trainMovementRef;
    public float speed;
    public Vector2 trainMovementVector;
    public float trainRotationAngleX;
    public float trainRotationAngleY;
    public float trainRotationAngleZ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.gameObject.name == "TrainMovementScriptObject")
        {
            trainMovementRef = trigger.GetComponent<trainMovement>();
            trainMovementRef.trainSpeed = speed;
            trainMovementRef.trainMovementVector = trainMovementVector;
            trainMovementRef.trainRotationAngleX = trainRotationAngleX;
            trainMovementRef.trainRotationAngleY = trainRotationAngleY;
            trainMovementRef.trainRotationAngleZ = trainRotationAngleZ;
            if (this.gameObject.tag == "TrainTranslate")
            {
                trainMovementRef.translateObject = true;
            }

            else if (this.gameObject.tag == "TrainRotate")
            {
                trainMovementRef.rotateObject = true;
            }
            

        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.name == "TrainMovementScriptObject")
        {
            trainMovementRef = trigger.GetComponent<trainMovement>();
            trainMovementRef.trainSpeed = 0;
            trainMovementRef.trainMovementVector = new Vector2 (0, 0);
            trainMovementRef.translateObject = false;
        }
    }
}
