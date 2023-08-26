using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]//UI의 최소단위는 Canvas 단위로 구분할 것이기 떄문에 UIMonoBehaviour는 Canvas컴포넌트가 필요하다
public class UIMonoBehaviour : MonoBehaviour, IUI
{
    public int sortOrder
    {
        get => canvas.sortingOrder;
        set => canvas.sortingOrder = value;
    }

    protected Canvas canvas;
    protected UIManager manager;

    public event Action onShow;
    public event Action onHide;

    public void Show()
    {
        manager.Push(this);//매니저에게 이거(this)를 제일 위에 띄워달라고 함
        gameObject.SetActive(true);
        onShow?.Invoke();
    }
    /// <summary>
    /// UI 비활성화
    /// </summary>
    public void Hide()
    {
        manager.Pop(this);//매니저에게 이거(this)를 빼달라고 함
        gameObject.SetActive(false);
        onHide?.Invoke();
    }
    private void Awake()
    {
        canvas= GetComponent<Canvas>();
        manager = UIManager.instance;
        manager.Register(this);
    }

}
