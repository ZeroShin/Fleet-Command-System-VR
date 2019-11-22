using UnityEngine;
using UnityEditor;

public class PropellerBoats : MonoBehaviour
{
  public Transform[] propellers;
  public Transform[] rudder;
  private Rigidbody rb;

  public float engine_rpm { get; private set; }
  float throttle;
  int direction = 1;
  Transform tr;     //레버
    Transform tr1;  //핸들

  public float propellers_constant = 0.6F;
  public float engine_max_rpm = 600.0F;
  public float acceleration_cst = 1.0F;
  public float drag = 0.01F; //파도값.
  public GameObject lever; // 레버 오브젝트 가져오기.
    public GameObject handle; //핸들
    public float leverval; // 레버값
    public float normal; // 레버각도 0~1로 변환.
    public float handleval; // 핸들값

  float angle;

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
        if (leverval >= 330)
        {
            leverval = tr.rotation.eulerAngles.z - 330.0f;
        }
        else if (leverval < 90)
        {
            leverval = tr.rotation.eulerAngles.z + 30.0f;
        }
        normal = leverval / 60.0f; // 값을 0~1로 변환한다.

        //핸들 조작계
        //핸들의 움직인 값을 플로트로 받아온다. 초기값으로 설정된 95를 빼서 0으로 만들어준다.
        handleval = tr1.rotation.eulerAngles.z - 95.0f;

        float frame_rpm = engine_rpm * Time.deltaTime;
    for (int i = 0; i < propellers.Length; i++)
    {
      propellers[i].localRotation = Quaternion.Euler(propellers[i].localRotation.eulerAngles + new Vector3(0, 0, -frame_rpm));
      rb.AddForceAtPosition(Quaternion.Euler(0, angle, 0) * propellers[i].forward * propellers_constant * engine_rpm, propellers[i].position);
    }

    throttle *= (1.0F - drag * 0.001F); // 감속 시키기 위한 code
    engine_rpm = throttle * engine_max_rpm * direction; // 속도에 맥스를 곱한값은 rpm

    angle = Mathf.Lerp(angle, 0.0F, 0.02F);
    for (int i = 0; i < rudder.Length; i++)
      rudder[i].localRotation = Quaternion.Euler(0, angle, 0);
  }

  public void ThrottleUp()
  {
        //계산한 노멀값을 스로틀에 대입한다.
        throttle = normal;

        // 밑은 원래있는코드들
        //throttle += acceleration_cst * 0.001F;
        ////최대치는 레버값과 동일하게 한다.
        //if (throttle > 1)
        //    throttle = 1;
    }

  public void ThrottleDown()
  {
    throttle -= acceleration_cst * 0.001F;
    if (throttle < 0)
      throttle = 0;
  }

  public void Brake()
  {
    throttle *= 0.9F;
  }

  public void Reverse()
  {
    direction *= -1;
  }

  public void RudderRight()
  {
        angle = handleval / 2.0f ;
  }

  public void RudderLeft()
  {
        angle = handleval / 2.0f;
  }

  //void OnDrawGizmos()
  //{
  //  Handles.Label(propellers[0].position, engine_rpm.ToString());
  //}
}
