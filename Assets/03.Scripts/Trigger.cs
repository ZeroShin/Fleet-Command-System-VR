using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    //이 스크립트는 트리거를 눌러야만 움직일 수 있도록 하려고 했지만 안함.
    Collider coll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger))
        coll.isTrigger = false;
        
    }
}
