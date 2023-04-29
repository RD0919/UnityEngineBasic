using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//delegate : 특정 형식의 함수를 참조하는 형식
//event : 한정자 / 구독은 되지만 외부에서 호출이 안됨

public class StartButton : MonoBehaviour
{

    [SerializeField] private Button _start;

    private void Awake()
    {
        _start.onClick.AddListener(() => Debug.Log("Start Clicked"));

        //_start.onClick.AddListener(StartClickedLog);
    }
    /// <summary>
    ///private void StartClickedLog()
    ///{
    ///   Debug.Log("Start Clicked");
    ///} 
    ///람다식 표현을 풀면
    /// </summary>
    
}


