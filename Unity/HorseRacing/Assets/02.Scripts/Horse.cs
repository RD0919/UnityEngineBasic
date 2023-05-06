using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//rigidbody�� �ǵ�� ������ �ٽ� �ؾߵǼ� �����ؾ��Ѵ�
public class Horse : MonoBehaviour
{
    //[SerializeField] : ����ȭ => Field ��� ������ ����ȭ 
    //��ü�� �ý�Ʈ ���� �����ͷ� ��ȯ
    //[DeSerializeField]
    //[SerializeField]�� ���� ���� : private�� ����ϸ� �ܺο��� ������� ���ؼ� �ν���Ʈ â�� ���� �ʴµ� [SerializeField]�� ����ϸ�  HorseEditor���� ������ ���������� private�� ������� �ν���Ʈ â�� ���´�
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
        //rigidbody�� ������ GameObject�� Transform�� ��Ÿ�ӿ� ���� �����ϸ�
        //speed ���� ���� ���������� �ٽ� �����ؾ��ϱ� ������
        //Rigidbody.MovePosition���� �̿��ϼ� �����ؾ���.
        //(�д� ���� Rigidbody.position �̳� Transform.position �̳� ������ ����)
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
