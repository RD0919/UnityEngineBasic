using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// ��ũ��Ʈ �ν��Ͻ��� ó�� �ε�� �� ȣ��.
    /// �� ��ũ��Ʈ�� ������Ʈ�� ������ GameOdject�� Ȱ��ȭ �Ǿ�� ȣ���
    /// MonoBehaviour���� �����ڸ� ���ؼ� ������ �� ���� ������, Awake()���� ����� �ʱ�ȭ �� 
    /// </summary>
    private void Awake()
    {
        Debug.Log("Awake");
    }

    /// <summary>
    /// �� ��ũ��Ʈ �ν��Ͻ��� Ȱ��ȭ�ɶ����� ȣ���
    ///  + �� ��ũ��Ʈ�� ������Ʈ�� ������ GameObject�� Ȱ��ȭ �� ������ ȣ���
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    /// <summary>
    /// ��� ��� ������ �ʱⰪ���� ���� Editor������ ����
    /// ��ũ��Ʈ �ν��Ͻ��� Editor���� GameObject�� AppComponent ���� �� ȣ��
    /// </summary>
    private void Reset()
    {
        Debug.Log("Reset");
    }

    /// <summary>
    /// ������ ȣ�� ���� �ѹ��� ȣ���
    /// Awake�� �ʱ�ȭ�� �Ϸ��� �ٸ� ��ü�� ������ ���ؼ� �ʱ�ȭ�ؾ��ϴ� ������ �ִ� ���/
    /// ó���� ��ü���� �ѹ� �����ؾ��ϴ� ��� � ����� �� �ִ�
    /// </summary>
    private void Start()
    {
        Debug.Log("Start");
    }

    /// <summary>
    /// ���� ������ �ӵ��� �������� ȣ���
    /// ����������� ������ �� �̺�Ʈ�Լ����� �����ؾߵ�
    /// </summary>
    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
    }

    /// <summary>
    /// trigger�� �ٸ� rigidbody�� ��ġ�� ������ ȣ���.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}�� Ʈ���� ��");
    }

    /// <summary>
    /// trigger �� �ٸ�  Colloder�� ��ó������ �Լ� ȣ���
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"{other.name} �� Ʈ���� �Ǵ� ��");
    }

    /// <summary>
    /// trigger�� �ٸ� Collider�� �����ִٰ� ����� ���� ȣ���.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.name} �� Ʈ���� ������");
    }


    /// <summary>
    /// Collider/Rigidbody �� �ٸ� rigbody/Collider�� �浹�ϴ� ���� ȣ��
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name} ��(��) �浹��");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log($"{collision.gameObject} ��(��) �浹�� ����");
    }

    private void OnMouseOver()
    {
        Debug.Log("���콺�� ����Ű�� ��.....");
    }

    /// <summary>
    /// �� ������ ���� ȣ��
    /// ��� ���ɸ��� ������ �ֱⰡ �޶���
    /// </summary>
    private void Update()
    {
        //Debug.Log("������Ʈ");
    }

    /// <summary>
    /// update �� Coroutine ���� ��� ���������� �������� ȣ���
    /// </summary>
    private void LateUpdate()
    {
        //Debug.Log("����Ʈ ������Ʈ");
    }

    /// <summary>
    /// Editer���� Gizmo ������ �ϱ� ���� ������ �� �� ȣ���ϴ� �Լ�
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(Vector3.up * 2.0f, Vector3.one * 2.0f);
        Gizmos.color= Color.cyan;
        Gizmos.DrawWireSphere(Vector3.up * 1.0f + Vector3.right * 1.0f, 1.0f);
    }

    private void OnApplicationPause(bool pause)
    {
        
    }

    /// <summary>
    /// ��ũ��Ʈ �ν��Ͻ��� ��Ȱ��ȭ �ɶ����� ȣ��
    /// </summary>
    private void OnDisable()
    {
        Debug.Log("Disable");
    }

    /// <summary>
    /// ��ũ��Ʈ �ν���Ʈ�� �ı��ɶ� ȣ��
    /// </summary>
    private void OnDestroy()
    {
        Debug.Log("Destory");
    }

}
