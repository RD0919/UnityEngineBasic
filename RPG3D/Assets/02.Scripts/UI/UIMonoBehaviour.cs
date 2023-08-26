using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]//UI�� �ּҴ����� Canvas ������ ������ ���̱� ������ UIMonoBehaviour�� Canvas������Ʈ�� �ʿ��ϴ�
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
        manager.Push(this);//�Ŵ������� �̰�(this)�� ���� ���� ����޶�� ��
        gameObject.SetActive(true);
        onShow?.Invoke();
    }
    /// <summary>
    /// UI ��Ȱ��ȭ
    /// </summary>
    public void Hide()
    {
        manager.Pop(this);//�Ŵ������� �̰�(this)�� ���޶�� ��
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
