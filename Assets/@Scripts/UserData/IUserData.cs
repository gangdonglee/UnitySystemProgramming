using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserData 
{
    // �⺻������ ������ �ʱ�ȭ
    void SetDefaultData();
    // ������ �ε�
    bool LoadData();
    // ������ ����
    bool SaveData();
}
