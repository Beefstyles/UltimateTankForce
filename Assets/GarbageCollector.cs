using UnityEngine;
using System.Collections;

public class GarbageCollector : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag != "Obstacles" && coll.gameObject.tag != "TrainRotate" && coll.gameObject.tag != "TrainTranslate")
        {
            Destroy(coll.gameObject);
        }
    }
}
