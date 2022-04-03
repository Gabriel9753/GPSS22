using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFramerate : MonoBehaviour{

    [SerializeField] private int frameRate = 60;
    // Start is called before the first frame update
    void Start(){
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = frameRate;
    }

}
