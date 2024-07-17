using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    // �� ��ȯ �� �������� ����
    protected bool m_IsDestoryOnLoad = false;

    //�� Ŭ������ Static Instance ����
    protected static T m_Instance;

    public static T Instacne
    {
        get { return m_Instance; }
    }

    private void Awake()
    {
        Init();
    }
    protected virtual void Init()
    {
        if (m_Instance == null)
        {
            m_Instance = (T)this;

            if (!m_IsDestoryOnLoad) { DontDestroyOnLoad(this); }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // ���� �� ����Ǵ� �Լ�
    protected virtual void OnDestory()
    {
        Dispose();
    }
    // ���� �� �߰��� ó���� �־���� �۾��� ���⼭ ó��
    protected virtual void Dispose()
    {
        m_Instance = null;
    }
}
