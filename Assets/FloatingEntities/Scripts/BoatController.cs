using UnityEngine;
using System.Collections;

public class BoatController : MonoBehaviour
{
  public PropellerBoats ship;
  bool forward = true;
    public GameObject lever; //레버 
    public GameObject handle; //핸들
    Transform tr;   //레버
    Transform tr1;  //핸들
    private float LeverX = 30.0f;
    private float handleZ = 95.0f;

    private void Awake()
    {
        tr = lever.gameObject.GetComponent<Transform>(); //레버의 트렌스폼 가져오기
        tr1 = handle.gameObject.GetComponent<Transform>(); //조타의 트렌스폼 가져오기
    }
    void Update()
   {
        //레버의 값을 지속적으로 받아온다. 값을 정제한다.
        LeverX = tr.rotation.eulerAngles.z;
        if(LeverX >= 330)
        {
            LeverX = tr.rotation.eulerAngles.z - 330.0f;
        }
        else if(LeverX < 90)
        {
            LeverX = tr.rotation.eulerAngles.z + 30.0f;
        }
        //핸들의 값을 지속적으로 받아온다.
        handleZ = tr1.rotation.eulerAngles.z;

        //핸들이 기점으로부터 왼쪽으로 움직였는지 오른쪽으로 움직였는지를 확인한다.
        if (handleZ > 95)
            ship.RudderLeft();
        else if (handleZ < 95)
            ship.RudderRight();

    if (forward)
    {
            //레버값을 조절한다.
            //30도를 제어하기 위해서 레버의 움직임이 0이 아닐때 움직인다.
            if (LeverX > 1)
            {
                ship.ThrottleUp();
            }
    }
    //else
    //{
    //  if (Input.GetKey(KeyCode.S))
    //    ship.ThrottleUp();
    //  else if (Input.GetKey(KeyCode.W))
    //  {
    //    ship.ThrottleDown();
    //    ship.Brake();
    //  }
    //}

    //if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
    //  ship.ThrottleDown();

    //if (ship.engine_rpm == 0 && Input.GetKeyDown(KeyCode.S) && forward)
    //{
    //  forward = false;
    //  ship.Reverse();
    //}
    //else if (ship.engine_rpm == 0 && Input.GetKeyDown(KeyCode.W) && !forward)
    //{
    //  forward = true;
    //  ship.Reverse();
    //}
  }

}
