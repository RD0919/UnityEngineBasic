using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RaceManage : MonoBehaviour
{
    [SerializeField] private Horse[] _horses;
    private Horse[] _horsesFinished;
    private int _grade;


    /// <summary>
    /// 경주 시작, 말들을 출발 시킴
    /// </summary>
    public void StartRace()
    {
        for (int i = 0; i < _horses.Length; i++)
        {
            _horses[i].doMove = true;
        }
        
    }

    /// <summary>
    /// 경주 종료. 1, 2, 3등을 UI에 띄워줌.
    /// </summary>
    public void FinishRace()
    {
        
    }

    /// <summary>
    /// 도착한 말 등록
    /// </summary>
    public void RegisterFinishedHorse(Horse horse)
    {
        horse.doMove = false;
        _horsesFinished[_grade] = horse;
       

        if(_grade < _horses.Length -1)
             _grade++;
        else
            FinishRace();

         

    }
    private void Awake()
    {
        _horsesFinished = new Horse[_horses.Length];
        //참조 배열
    }
}

