using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonBehaviour<UIManager>
{
    public Transform UICanvasTrs;
    public Transform ClosedUITrs;
	
    private BaseUI m_FrontUI;
    private Dictionary<System.Type, GameObject> m_OpenUIPool = new Dictionary<System.Type, GameObject>();
    private Dictionary<System.Type, GameObject> m_ClosedUIPool = new Dictionary<System.Type, GameObject>();

    private GoodsUI m_GoodsUI;

    protected override void Init()
    {
        base.Init();

        m_GoodsUI = FindObjectOfType<GoodsUI>();
        if(!m_GoodsUI)
        {
            Logger.LogError("No goods ui component found.");
        }
    }


    private BaseUI GetUI<T>(out bool isAlreadyOpen)
    {
        System.Type uiType = typeof(T);

        BaseUI ui = null;
        isAlreadyOpen = false;

        if (m_OpenUIPool.ContainsKey(uiType))
        {
            ui = m_OpenUIPool[uiType].GetComponent<BaseUI>();
            isAlreadyOpen = true;
        }
        else if (m_ClosedUIPool.ContainsKey(uiType))
        {
            ui = m_ClosedUIPool[uiType].GetComponent<BaseUI>();
            m_ClosedUIPool.Remove(uiType);
        }
        else
        {
            var uiObj = Instantiate(Resources.Load($"UI/{uiType}", typeof(GameObject))) as GameObject;
            ui = uiObj.GetComponent<BaseUI>();
        }

        return ui;
    }

    public void OpenUI<T>(BaseUIData uiData)
    {
        System.Type uiType = typeof(T);

        Logger.Log($"{GetType()}::OpenUI({uiType})");

        bool isAlreadyOpen = false;
        var ui = GetUI<T>(out isAlreadyOpen);
        
        if (!ui)
        {
            Logger.LogError($"{uiType} does not exist.");
            return;
        }

        if(isAlreadyOpen)
        {
            Logger.LogError($"{uiType} is already open.");
            return;
        }

        var siblingIdx = UICanvasTrs.childCount - 1;
        ui.Init(UICanvasTrs);
        ui.transform.SetSiblingIndex(siblingIdx);
        ui.gameObject.SetActive(true);
        ui.SetInfo(uiData);
        ui.ShowUI();

        m_FrontUI = ui;
        m_OpenUIPool[uiType] = ui.gameObject;
    }

    public void CloseUI(BaseUI ui)
    {
        System.Type uiType = ui.GetType();

        Logger.Log($"CloseUI UI:{uiType}");

        ui.gameObject.SetActive(false);
        m_OpenUIPool.Remove(uiType);
        m_ClosedUIPool[uiType] = ui.gameObject;
        ui.transform.SetParent(ClosedUITrs);

        m_FrontUI = null;
        foreach (var item in m_OpenUIPool)
        {
            var openUI = item.Value.GetComponent<BaseUI>();
            m_FrontUI = openUI;
        }
    }

    public BaseUI GetActivePopup<T>()
    {
        var uiType = typeof(T);
        return m_OpenUIPool.ContainsKey(uiType) ? m_OpenUIPool[uiType].GetComponent<BaseUI>() : null;
    }

    public bool ExistsOpenUI()
    {
        return m_FrontUI != null;
    }

    public BaseUI GetCurrentFrontUI()
    {
        return m_FrontUI;
    }

    public void CloseCurrFrontUI()
    {
        m_FrontUI.CloseUI();
    }

    public void CloseAllOpenUI()
    {
        while (m_FrontUI)
        {
            m_FrontUI.CloseUI(true);
        }
    }

    public void EnableGoodsUI(bool value)
    {
        m_GoodsUI.gameObject.SetActive(value);

        if(value)
        {
            m_GoodsUI.SetValues();
        }
    }
}
