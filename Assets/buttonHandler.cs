using UnityEngine;
using System.Collections;

public class buttonHandler : MonoBehaviour {


    public void Play1v1()
    {
        Application.LoadLevel("MainArena2Player");
    }
    public void PlayFFA4Player()
    {
        Application.LoadLevel("MainArena4Player");
    }
    public void PlayTrainLevel()
    {
        Application.LoadLevel("TrainLevelTrack");
    }
}
