using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLine : MonoBehaviour
{
    [SerializeField] private LayerMask _tergetMask;
    [SerializeField] private RaceManage _raceManage;
    private void OnTriggerEnter(Collider other)
    {
        //layer와 _tergetMask의 의미 또는 설명이 필요함
        if ((1 << other.gameObject.layer & _tergetMask)  > 0)
        {
            _raceManage.RegisterFinishedHorse(other.GetComponent<Horse>());
        }//GetComponent<Horse>() 질문 필요
    }

}
