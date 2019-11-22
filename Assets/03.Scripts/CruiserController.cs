using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiserController : MonoBehaviour
{
    public CruiserMove ship; // 크루저 무브 스르립트 내부 함수를 사용하기 위해서 선언한다.
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
        if (LeverX > 300)
        {
            LeverX = tr.rotation.eulerAngles.z - 330.0f;
        }
        else if (LeverX < 60)
        {
            LeverX = tr.rotation.eulerAngles.z + 30.0f;
        }

        //핸들의 값을 지속적으로 받아온다.
        handleZ = tr1.rotation.eulerAngles.z;

        //핸들이 기점으로부터 왼쪽으로 움직였는지 오른쪽으로 움직였는지를 확인한다.
        if (handleZ > 95)
            ship.AngleMove();
        else if (handleZ < 95)
            ship.AngleMove();
 
    }
}
