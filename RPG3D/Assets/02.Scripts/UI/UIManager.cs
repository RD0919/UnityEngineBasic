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
    /// 원하는 타입의 UI를 받아올 때 사용
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
            ui = (T)value; //인벤토리
            return true;
        }
        ui = default;
        return false;
    }

    public void Push(IUI ui)
    {
        //해당 ui가 가장 마지막에 있으면 Push 할 필요 없음
        if(uisShown.Count > 0 && uisShown.Last.Value == ui)
        {
            return;
        }

        int sortOder = 0;
        //기존에 켜진 ui가 있으면 가장 마지막에 있는 ui보다 더 큰 sortOder로 세팅해야함.
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
        //현재 활성화된 UI가 하나도 없으면 return 있으면 활성화된 UI들 중 마지막 UI를 숨긴다
        if(uisShown.Count <= 0)
            return;
        uisShown.Last.Value.Hide();
    }

}
