using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//rigidbody를 건들면 연산을 다시 해야되서 주의해야한다
public class Horse : MonoBehaviour
{
    //[SerializeField] : 직렬화 => Field 멥버 변수를 직렬화 
    //객체를 택스트 파일 데이터로 변환
    //[DeSerializeField]
    //[SerializeField]를 쓰는 이유 : private를 사용하면 외부에서 사용하지 못해서 인스펙트 창에 쓰지 않는데 [SerializeField]를 사용하면  HorseEditor에만 접근이 가능해져서 private과 상관없이 인스펙트 창에 나온다
    public bool doMove;
    [SerializeField] private float _speed;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float _stability;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float _stamina;
    private float _speedRefreshTimeMark;
    private float _staminaRefreshTimeMark;
    private float _speedModified;
    private float _staminaModified;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _speedModified = _speed;
        _staminaModified = _stamina;
    }

    private void FixedUpdate()
    {
        if (doMove)
        {
            RefreshSpeed();
            RefreshStamina();
            Move();
        }
    }

    private void Move()
    {
        //rigidbody를 가지는 GameObject의 Transform을 런타임에 직접 수정하면
        //speed 값과 같은 물리연산을 다시 수행해야하기 때문에
        //Rigidbody.MovePosition등을 이용하서 수정해야함.
        //(읽는 것은 Rigidbody.position 이나 Transform.position 이나 별차이 없음)
        _rb.MovePosition(transform.position + Vector3.forward * _speedModified * Time.fixedDeltaTime);


        transform.Translate(Vector3.forward * _speedModified * _speed * Time.fixedDeltaTime);
    }

    private void RefreshSpeed()
    {
        if(Time.time - _speedRefreshTimeMark > (0.1f / (_staminaModified + 0.001f)))
        {
            _speedModified = Random.Range(_stability, 1.0f) * _speed * (_staminaModified / _stamina);
            _speedRefreshTimeMark = Time.time;
        }
    }

    private void RefreshStamina()
    {
        if(Time.time - _staminaRefreshTimeMark > (_staminaModified + 0.1f / (1.0f + 0.1f)))
        {
            if(_staminaModified> 0.1f)
                _staminaModified -= 0.01f;
            _staminaRefreshTimeMark = Time.time;
        }

    }

}
