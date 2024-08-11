using TMPro;
using UnityEngine;

public class SettingsUI : BaseUI
{
    // Game Version
    public TextMeshProUGUI GameVersionTxt;

    public GameObject SoundOnToggle;
    public GameObject SoundOffToggle;

    // ������å �� ����Ʈ ��ũ
    private const string PRIVACY_POLICY_URL = "https://www.inflearn.com/";

    public override void SetInfo(BaseUIData uiData)
    {
        base.SetInfo(uiData);

        SetGameVersion();

        var userSettingData = UserDataManager.Instance.GetUserData<UserSettingsData>();
        if(userSettingData != null )
        {
            SetSoundSetting(userSettingData.Sound);
        }

    }

    private void SetGameVersion()
    {
        GameVersionTxt.text = $"Version:{Application.version}";
    }

    private void SetSoundSetting(bool sound)
    {
        SoundOnToggle.SetActive(sound);
        SoundOffToggle.SetActive(!sound);
    }

    // ���� ���� OFF �Լ�
    public void OnClickSoundOnToggle()
    {
        Logger.Log($"{GetType()}::OnClickSoundToggle");

        AudioManager.Instance.PlaySFX(SFX.ui_button_click);

        var userSettingData = UserDataManager.Instance.GetUserData<UserSettingsData>();
        if( userSettingData != null )
        {
            userSettingData.Sound = false;
            UserDataManager.Instance.SaveUserData();
            AudioManager.Instance.Mute();
            SetSoundSetting(userSettingData.Sound);
        }
    }

    // ���� ���� ON �Լ�
    public void OnClickSoundOffToggle()
    {
        Logger.Log($"{GetType()}::OnClickSoundOffToggle");

        AudioManager.Instance.PlaySFX(SFX.ui_button_click);

        var userSettingData = UserDataManager.Instance.GetUserData<UserSettingsData>();
        if (userSettingData != null)
        {
            userSettingData.Sound = true;
            UserDataManager.Instance.SaveUserData();
            AudioManager.Instance.UnMute();
            SetSoundSetting(userSettingData.Sound);
        }
    }

    public void OnClickPrivacyPolicyURL()
    {
        Logger.Log($"{GetType()}::OnClickPrivacyPolicyURL");

        AudioManager.Instance.PlaySFX(SFX.ui_button_click);
        Application.OpenURL(PRIVACY_POLICY_URL);
    }

}
