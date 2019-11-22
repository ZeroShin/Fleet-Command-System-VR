using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShip : MonoBehaviour
{
    //visible Properties
    public Transform Motor; // 엔진의 위치를 넣어줘야 한다.
    public float steerPower = 500f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;

    //used Components
    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;

    public void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        StartRotation = Motor.localRotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var forceDirection = transform.forward;
        var steer = 0;

        //steer direction
        //if (좌)
        //    steer = 1;
        //if (우)
        //    steer = -1;

        //Rotational Force
        Rigidbody.AddForceAtPosition(steer * transform.right * steerPower / 100f, Motor.position);

        //compute vectors
        var forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);
        var targetVel = Vector3.zero;
    }
}
