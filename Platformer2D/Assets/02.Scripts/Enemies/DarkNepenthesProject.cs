using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��Ʈ�� RR
/// �̸� ����
/// ��Ʈ = 1 * 2�� �¼��� �����ʿ��� �������� ǥ��
/// </summary>
/// 
public class DarkNepenthesProject : MonoBehaviour
{
    private GameObject owner;
    private Vector2 velocity;
    private float damage;
    private LayerMask targetMask;

   public void SetUp(GameObject owner, Vector2 velocity, float demage, LayerMask targetMask)
    {
        this.owner = owner;
        this.velocity = velocity;
        this.damage = demage;
        this.targetMask = targetMask;
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)velocity * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((1 << collision.gameObject.layer & targetMask) > 0)//Layer�� int���� ���� ��ŭ 1�� �������� �δ�
        {
            if(collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(owner, damage);
            }
        }
    }

}
