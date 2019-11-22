using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiserMove : MonoBehaviour
{
    private Rigidbody rb;
    public float engine_rpm { get; private set; }
    float throttle;
    Transform tr;    //레버
    Transform tr1;  //핸들

    //public float propellers_constant = 0.6F;
    public float engine_max_rpm = 600.0F;
    public float acceleration_cst = 1.0F;
    public float drag = 0.01F; //파도값?
    public GameObject lever; // 레버 오브젝트 가져오기.
    public GameObject handle; //핸들
    public float rotSpeed = 1.0f;

    //float frame_rpm;
    float angle = 0.0f;
    float leverval; // 레버값
    float normal; // 레버각도 0~1로 변환.
    float handleval; // 핸들값


    void Awake()
    {
        tr = lever.gameObject.GetComponent<Transform>(); //레버의 트렌스폼 가져오기
        tr1 = handle.gameObject.GetComponent<Transform>(); //조타의 트렌스폼 가져오기
        engine_rpm = 0F;
        throttle = 0F;
        normal = 0f; // 0초기화
        rb = GetComponent<Rigidbody>();
        leverval = 0.0f;//레버 초기화
        handleval = 0.0f; //핸들 초기화
    }

    void Update()
    {
        //레버 조작계
        leverval = tr.rotation.eulerAngles.z;
        if (leverval >= 300)
        {
            leverval = tr.rotation.eulerAngles.z - 330.0f;
        }
        else if (leverval < 60)
        {
            leverval = tr.rotation.eulerAngles.z + 30.0f;
        }
        //30도를 제어하기 위해서 레버의 움직임이 0이 아닐때 움직인다.
        if (leverval > 1)
        {
            ThrottleUp();
        }
        else if (leverval < 1)
            throttle = 0f;
        normal = leverval / 60.0f; // 값을 0~1로 변환한다.

        //핸들 조작계
        //핸들의 움직인 값을 플로트로 받아온다. 초기값으로 설정된 95를 빼서 0으로 만들어준다.
        handleval = tr1.rotation.eulerAngles.z - 95.0f;

        //엔진의 rpm을 가져온다.
        //frame_rpm = engine_rpm * Time.deltaTime;

        //트렌스레이트로 이동을 하려고 함.
        transform.Translate(Vector3.forward * engine_rpm * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(0, -angle, 0);
        //힘을 주는데 벡터값을 가지고 힘을 주고 어느위치에서 힘을 줄지 결정한다.
        // rb.AddForceAtPosition(Quaternion.Euler(0, angle, 0) * propellers.forward * propellers_constant * engine_rpm, propellers.position);
       

        // 스로틀에 맥스rpm을 곱한값은 엔진rpm
        engine_rpm = throttle * engine_max_rpm; 
        throttle *= (1.0F - drag * 0.001F); // 알수없음...?  
        //각도는 러프를 사용해서 천천히 따라가도록 하게 만든다.
        //angle = Mathf.Lerp(angle, 0.0F, 0.02F);
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -angle, 0), Time.deltaTime * rotSpeed);
        // 폭탄이 터진다면 진동울리게 함. 주파수, 진폭 ( 0~1사이값을 받는다), 진동컨트롤러(양손동시 선언 안됨)
        //OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
        //OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
    }

    public void ThrottleUp()
    {
        //계산한 노멀값을 스로틀에 대입한다.
        throttle = normal;
        //스로틀이 부득이 1을 넘어갈 경우에는 1로 더이상 올라가지 못하도록 한다.
        if (throttle > 1)
            throttle = 1;
    }

    public void AngleMove()
    {
        angle = handleval / 2.0f;
    }
}
