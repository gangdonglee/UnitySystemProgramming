using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    // 씬 전환 시 삭제할지 여부
    protected bool m_IsDestoryOnLoad = false;

    //이 클래스의 Static Instance 변수
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
    // 삭제 시 실행되는 함수
    protected virtual void OnDestory()
    {
        Dispose();
    }
    // 삭제 시 추가로 처리해 주어야할 작업을 여기서 처리
    protected virtual void Dispose()
    {
        m_Instance = null;
    }
}
