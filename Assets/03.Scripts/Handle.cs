using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    float handleUpLimit = 185; // 조타의 움직임을 제어한다.
    float handleDownLimit = 5; // 조타의 움직임을 제어한다.


    void Start()
    {
        //초기값을 설정한다.
        // 95를 설정한 이유는 0값에서 쓰레기값을 받아오기 때문이다. 0만아니면된다.
        transform.rotation = Quaternion.Euler(20, 0, 95);
    }

    // Update is called once per frame
    void Update()
    {
        //print(transform.rotation.eulerAngles.z);
        // 한계치는 90도이고 더 나아가면 최대각도 90도로 고정한다.
        if (transform.rotation.eulerAngles.z < handleDownLimit)
        {
                transform.rotation = Quaternion.Euler(20, 0, 5);
        }
        if (transform.rotation.eulerAngles.z > handleUpLimit)
        {
            transform.rotation = Quaternion.Euler(20, 0, 185);
        }
    }
}
