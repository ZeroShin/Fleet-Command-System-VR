using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    float leverCorr = 330; // 레버의 움직임을 제어한다.
    float leverLimit = 30; // 레버의 움직임을 제어한다.
    float tmp = 0;

    void Start()
    {
        //초기값은 -30도에서 시작한다.
        transform.rotation = Quaternion.Euler(0, 90, -30);
        tmp = transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        //print(transform.rotation.eulerAngles.z);
        //한계치는 30도이고 그값이하로 떨어지면 30도로 고정한다.
        tmp = transform.rotation.eulerAngles.z;
        //330도를 넘어가면 330을 빼준다.
        if(tmp >= leverCorr)
        {
            tmp = transform.rotation.eulerAngles.z - leverCorr;
        }
        if (tmp > leverLimit)
        {
            if (transform.rotation.eulerAngles.z < 90)
            {   
                transform.rotation = Quaternion.Euler(0, 90, 30);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 90, -30);
            }
        }
    }
}
