using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//delegate : Ư�� ������ �Լ��� �����ϴ� ����
//event : ������ / ������ ������ �ܺο��� ȣ���� �ȵ�

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
    ///���ٽ� ǥ���� Ǯ��
    /// </summary>
    
}


