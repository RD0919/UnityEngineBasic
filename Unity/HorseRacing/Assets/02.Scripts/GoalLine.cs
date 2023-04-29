using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLine : MonoBehaviour
{
    [SerializeField] private LayerMask _tergetMask;
    [SerializeField] private RaceManage _raceManage;
    private void OnTriggerEnter(Collider other)
    {
        if ((1 << other.gameObject.layer & _tergetMask)  > 0)// ���� �ʿ�
        {
            _raceManage.RegisterFinishedHorse(other.GetComponent<Horse>());
        }//GetComponent<Horse>() ���� �ʿ�
    }

}
