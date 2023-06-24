using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 컨트롤 RR
/// 이름 수정
/// 비트 = 1 * 2의 승수롤 오른쪽에서 왼쪽으로 표현
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
        if((1 << collision.gameObject.layer & targetMask) > 0)//Layer가 int여서 정수 만큼 1을 왼쪽으로 민다
        {
            if(collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(owner, damage);
            }
        }
    }

}
