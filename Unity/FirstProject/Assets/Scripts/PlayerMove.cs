using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //SerializedField : Attribute
    //해당 필드를 인스펙터창에 노출시키는 속성
    [SerializeField]private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    /// <summary>
    /// 스크립트 인스턴스가 처음 로드될 때 호출.
    /// 이 스크립트를 컴포넌트로 가지는 GameOdject가 활성화 되어야 호출됨
    /// MonoBehaviour들은 생성자를 통해서 생성할 수 없기 떼문에, Awake()에서 멥버을 초기화 함 
    /// </summary>
    private void Awake()
    {
        Debug.Log("Awake");
    }

    /// <summary>
    /// 이 스크립트 인스턴스가 활성화될때마다 호출됨
    ///  + 이 스크립트를 컴포넌트로 가지는 GameObject가 활성화 할 때마다 호출됨
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    /// <summary>
    /// 모든 멤버 변수를 초기값으로 설정 Editor에서만 동작
    /// 스크립트 인스턴스를 Editor에서 GameObject에 AppComponent 했을 때 호출
    /// </summary>
    private void Reset()
    {
        Debug.Log("Reset");
    }

    /// <summary>
    /// 프레임 호출 전에 한번만 호출됨
    /// Awake로 초기화를 완료한 다른 객체의 참조를 통해서 초기화해야하는 값들이 있는 경우/
    /// 처음에 객체들을 한번 생성해야하는 경우 등에 사용할 수 있다
    /// </summary>
    private void Start()
    {
        Debug.Log("Start");
    }

    /// <summary>
    /// 고정 프레임 속도로 매프레임 호출됨
    /// 물리연산관련 로직은 이 이벤트함수에서 수행해야됨
    /// </summary>
    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
    }

    /// <summary>
    /// trigger가 다른 rigidbody와 겹치는 순간에 호출됨.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}이 트리거 됨");
    }

    /// <summary>
    /// trigger 가 다른  Colloder와 겹처있으면 게속 호출됨
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"{other.name} 이 트리거 되는 중");
    }

    /// <summary>
    /// trigger가 다른 Collider와 겹쳐있다가 벗어나는 순간 호출됨.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.name} 이 트리거 해제됨");
    }


    /// <summary>
    /// Collider/Rigidbody 가 다른 rigbody/Collider와 충돌하는 순간 호출
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name} 이(가) 충돌함");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log($"{collision.gameObject} 이(가) 충돌이 끝남");
    }

    private void OnMouseOver()
    {
        Debug.Log("마우스가 가리키는 중.....");
    }

    /// <summary>
    /// 매 프레임 마다 호출
    /// 기기 성능마다 프레임 주기가 달라짐
    /// </summary>
    private void Update()
    {
        //Debug.Log("업데이트");
        //Input 클래스 : 사용자 입력을 게임 로직에서 처리하기위한 클래스
        float h = Input.GetAxis("수평축");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");
        // 거리 = 속력 x 시간
        //거리변화량 = 속력 x 시간변화량
        //벡터의 크기 = 각축의 제곱의 합에 루트
        //transform.position += new Vector3(h, 0, v).normalized *_moveSpeed *Time.deltaTime;
        //nomalized : 일반화
        transform.Translate(new Vector3(h, 0, v).normalized * _moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up *r *_rotateSpeed *Time.deltaTime);

    }

    /// <summary>
    /// update 및 Coroutine 등의 모든 로직연산후 마지막에 호출됨
    /// </summary>
    private void LateUpdate()
    {
        //Debug.Log("레이트 업데이트");
    }

    /// <summary>
    /// Editer에서 Gizmo 렌더링 하기 위한 연산을 할 때 호출하는 함수
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawCube(Vector3.up * 2.0f, Vector3.one * 2.0f);
        //Gizmos.color= Color.cyan;
        //Gizmos.DrawWireSphere(Vector3.up * 1.0f + Vector3.right * 1.0f, 1.0f);
    }

    private void OnApplicationPause(bool pause)
    {
        
    }

    /// <summary>
    /// 스크립트 인스턴스가 비활성화 될때마다 호출
    /// </summary>
    private void OnDisable()
    {
        Debug.Log("Disable");
    }

    /// <summary>
    /// 스크립트 인스턴트가 파괴될때 호출
    /// </summary>
    private void OnDestroy()
    {
        Debug.Log("Destory");
    }

}
