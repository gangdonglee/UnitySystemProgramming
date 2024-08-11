using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIController : MonoBehaviour
{
    public void Init()
    {
        UIManager.Instance.EnableGoodsUI(true);
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            AudioManager.Instance.PlaySFX(SFX.ui_button_click);

            var frontUI = UIManager.Instance.GetCurrentFrontUI();
            if(frontUI != null)
            {
                frontUI.CloseUI();
            }
            else
            {
                var uiData = new ConfirmUIData();
                uiData.ConfirmType = ConfirmType.OK_CANCEL;
                uiData.TitleTxt = "Quit";
                uiData.DescTxt = "Do you want to quit game?";
                uiData.OKBtnTxt = "Quit";
                uiData.CancelBtnTxt = "Cancel";
                uiData.OnClickOKBtn = () =>
                {
                    Application.Quit();
                };
                UIManager.Instance.OpenUI<ConfirmUI>(uiData);
            }
        }
    }

    public void OnClickSettingBtn()
    {
        Logger.Log($"{GetType()}::OnClickSettingBtn");

        var uiData = new BaseUIData();
        UIManager.Instance.OpenUI<SettingsUI>(uiData);
    }
}
