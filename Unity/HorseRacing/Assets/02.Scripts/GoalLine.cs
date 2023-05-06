using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLine : MonoBehaviour
{
    [SerializeField] private LayerMask _tergetMask;
    [SerializeField] private RaceManage _raceManage;
    private void OnTriggerEnter(Collider other)
    {
        //layer�� _tergetMask�� �ǹ� �Ǵ� ������ �ʿ���
        if ((1 << other.gameObject.layer & _tergetMask)  > 0)
        {
            _raceManage.RegisterFinishedHorse(other.GetComponent<Horse>());
        }//GetComponent<Horse>() ���� �ʿ�
    }

}
