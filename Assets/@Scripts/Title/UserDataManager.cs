using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UserDataManager : SingletonBehaviour<UserDataManager>
{
    //����� ���� ������ ���� ����
    public bool ExistsSavedData { get; private set; }
    //��� ���� ������ �ν��Ͻ��� �����ϴ� �����̳�
    public List<IUserData> UserDataList { get; private set;} = new List<IUserData>();

    protected override void Init()
    {
        base.Init();

        // ��� ���� �����͸� userDataList�� �߰�
        UserDataList.Add(new UserSettingsData());
        UserDataList.Add(new UserGoodsData());
    }
    public void SetDefaultUserData()
    {
        for(int i = 0; i < UserDataList.Count; i++) {
            UserDataList[i].SetDefaultData();
        }
    }

    public void LoadUserData()
    {
        ExistsSavedData = PlayerPrefs.GetInt("ExistsSavedData") == 1 ? true : false;

        if(ExistsSavedData )
        {
            for(int i= 0; i < UserDataList.Count; i++)
            {
                UserDataList[i].LoadData();
            }
        }
    }

    public void SaveUserData()
    {
        bool hasSaveError = false;

        for(int i = 0; i < UserDataList.Count; i++)
        {
            bool isSaveSuccess = UserDataList[i].SaveData();
            if(!isSaveSuccess) { hasSaveError = true; }
        }

        if(!hasSaveError)
        {
            ExistsSavedData = true;
            PlayerPrefs.SetInt("ExistsSavedData", 1);
            PlayerPrefs.Save();
        }
    }

    // ����ȭ�鿡�� ���������� ���� �Լ�
    public T GetUserData<T>() where T : class, IUserData
    {
        return UserDataList.OfType<T>().FirstOrDefault();
    }
}
