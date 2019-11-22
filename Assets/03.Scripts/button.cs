using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    Transform btn; //버튼
    Vector3 First; // 초기값 저장
    float press = 0; //누름을 인지
    float Rtn = 0; //돌아올 값.
    float pressStart = 0.02f; //버튼을 이정도는 눌러야함.
    float sp = 3f;// 돌아오는 속도.

    // Start is called before the first frame update
    private void Awake()
    {
        btn = GetComponent<Transform>(); // 버튼의 트렌스폼을 가져온다.
        Rtn = btn.position.y; // 비교할 처음 값을 가져온다.
        First = btn.position;
    }

    // Update is called once per frame
    void Update()
    {
        press = btn.position.y;
        Debug.Log("초기값");
        Debug.Log(Rtn);
        Debug.Log("버튼값");
        Debug.Log(press);
        if((Rtn - press) >= pressStart)
        {
            //눌렸다면 모드 변환 코드를 삽입한다.
            Invoke("RN", 1); // 1초 뒤에 올라오게 만든다.
        }
    }
    void RN()
    {
        transform.position = Vector3.Lerp(transform.position, First, Time.deltaTime * sp);
    }
}
