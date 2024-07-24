using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUIData
{
    public Action OnShow;
    public Action OnClose;
}

public class BaseUI : MonoBehaviour
{
    public Animation m_UIOpenAnim;

    private Action m_OnShow;
    private Action m_OnClose;

    public virtual void Init(Transform anchor)
    {
        Logger.Log($"{GetType()} init.");

        m_OnShow = null;
        m_OnClose = null;

        transform.SetParent(anchor);

        var rectTransform = GetComponent<RectTransform>();
        if (!rectTransform)
        {
            Logger.LogError("UI does not have rectransform.");
            return;
        }

        rectTransform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.localScale = new Vector3(1f, 1f, 1f);
        rectTransform.offsetMin = new Vector2(0, 0);
        rectTransform.offsetMax = new Vector2(0, 0);
    }

    public virtual void SetInfo(BaseUIData uiData)
    {
        Logger.Log($"{GetType()} set info.");

        m_OnShow = uiData.OnShow;
        m_OnClose = uiData.OnClose;
    }

    public virtual void ShowUI()
    {
        if (m_UIOpenAnim)
        {
            m_UIOpenAnim.Play();
        }

        m_OnShow?.Invoke();
        m_OnShow = null;
    }

    public virtual void CloseUI(bool isCloseAll = false)
    {
        if (!isCloseAll)
        {
            m_OnClose?.Invoke();
        }
        m_OnClose = null;

        UIManager.Instance.CloseUI(this);
    }

    public virtual void OnClickCloseButton()
    {
        AudioManager.Instance.PlaySFX(SFX.ui_button_click);
        CloseUI();
    }
}
