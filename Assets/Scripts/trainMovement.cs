using UnityEngine;
using System.Collections;

public class trainMovement : MonoBehaviour {

    public Vector2 trainMovementVector;
    public Vector2 trainRotationVector;
    public float trainRotationAngleX;
    public float trainRotationAngleY;
    public float trainRotationAngleZ;
    public float trainSpeed = 100F;
    public GameObject train;
    TrainMovementPart trainMovementRef;
    public bool translateObject;
    public bool rotateObject;
    public float stageTimer;
	// Use this for initialization
	void Start () {
        stageTimer = 0F;
       }
	
	// Update is called once per frame
	void Update () {

        stageTimer += Time.deltaTime;

        if (stageTimer >= 0 && stageTimer <= 20)
        {
            trainMovementVector = new Vector2(1, 0);
            trainSpeed = 100F;
            Translation();
        }
        else if (stageTimer > 20 && stageTimer <= 30)
        {
            trainRotationAngleZ = -0.1F;
            Rotation();
        }

        else if (stageTimer > 30 && stageTimer <= 40)
        {
            trainMovementVector = new Vector2(1, 0);
            trainSpeed = 100F;
            Translation();
        }
        else if (rotateObject)
        {
            train.transform.Rotate(trainRotationAngleX, trainRotationAngleY, trainRotationAngleZ, Space.Self);
        }
	}

 void Translation()
    {
        train.transform.Translate(trainMovementVector * trainSpeed * Time.deltaTime, Space.Self);
    }

 void Rotation()
 {
     train.transform.Rotate(trainRotationAngleX, trainRotationAngleY, trainRotationAngleZ, Space.Self);
 }



}



