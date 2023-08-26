using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonoBase<UIManager>
{
    public Dictionary<Type, IUI> uis = new Dictionary<Type, IUI>();
    public LinkedList<IUI> uisShown = new LinkedList<IUI>(); 

    public void Register(IUI ui)
    {
        if (uis.TryAdd(ui.GetType(), ui) == false)
            throw new Exception($"[UIManager] : Failed to register {ui.GetType()}");
    }

    /// <summary>
    /// ���ϴ� Ÿ���� UI�� �޾ƿ� �� ���
    /// ex)
    /// if (UIManager.instance.TryGet(out InventoryUI ui)
    /// {
    ///     //Do somthing with InventoryUI
    /// }
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ui"></param>
    /// <returns></returns>

    public bool TryGet<T>(out T ui)
        where T : IUI
    {
        if (uis.TryGetValue(typeof(T), out IUI value))
        {
            ui = (T)value; //�κ��丮
            return true;
        }
        ui = default;
        return false;
    }

    public void Push(IUI ui)
    {
        //�ش� ui�� ���� �������� ������ Push �� �ʿ� ����
        if(uisShown.Count > 0 && uisShown.Last.Value == ui)
        {
            return;
        }

        int sortOder = 0;
        //������ ���� ui�� ������ ���� �������� �ִ� ui���� �� ū sortOder�� �����ؾ���.
        if (uisShown.Last != null)
        {
            sortOder = uisShown.Last.Value.sortOrder + 1;
        }
        ui.sortOrder = sortOder;
        uisShown.Remove(ui);
        uisShown.AddLast(ui);
    }

    public void Pop(IUI ui)
    {
        uisShown.Remove(ui);
    }

    public void HideLast()
    {
        //���� Ȱ��ȭ�� UI�� �ϳ��� ������ return ������ Ȱ��ȭ�� UI�� �� ������ UI�� �����
        if(uisShown.Count <= 0)
            return;
        uisShown.Last.Value.Hide();
    }

}
