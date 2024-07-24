using System;
using TMPro;
using UnityEngine.UI;

public enum ConfirmType
{
    OK,
    OK_CANCEL
}

public class ConfirmUIData : BaseUIData
{
    public ConfirmType ConfirmType;
    public string TitleTxt;
    public string DescTxt;
    public string OKBtnTxt;
    public Action OnClickOKBtn;
    public string CancelBtnTxt;
    public Action OnClickCancelBtn;
}

public class ConfirmUI : BaseUI
{
    public TextMeshProUGUI TitleTxt = null;
    public TextMeshProUGUI DescTxt = null;
    public Button OKBtn = null;
    public Button CancelBtn = null;
    public TextMeshProUGUI OKBtnTxt = null;
    public TextMeshProUGUI CancelBtnTxt = null;

    private ConfirmUIData m_ConfirmUIData = null;
    private Action m_OnClickOKBtn = null;
    private Action m_OnClickCancelBtn = null;

    public override void SetInfo(BaseUIData uiData)
    {
        base.SetInfo(uiData);

        m_ConfirmUIData = uiData as ConfirmUIData;

        TitleTxt.text = m_ConfirmUIData.TitleTxt;
        DescTxt.text = m_ConfirmUIData.DescTxt;
        OKBtnTxt.text = m_ConfirmUIData.OKBtnTxt;
        m_OnClickOKBtn = m_ConfirmUIData.OnClickOKBtn;
        CancelBtnTxt.text = m_ConfirmUIData.CancelBtnTxt;
        m_OnClickCancelBtn = m_ConfirmUIData.OnClickCancelBtn;

        OKBtn.gameObject.SetActive(true);
        CancelBtn.gameObject.SetActive(m_ConfirmUIData.ConfirmType == ConfirmType.OK_CANCEL);
    }

    public void OnClickOKBtn()
    {
        m_OnClickOKBtn?.Invoke();
        CloseUI();
    }

    public void OnClickCancelBtn()
    {
        m_OnClickCancelBtn?.Invoke();
        CloseUI();
    }
}
