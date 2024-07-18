using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    //로고
    public Animation LogoAnim;
    public TextMeshProUGUI LogoTxt;

    //타이틀
    public GameObject Title;
    public Slider LoadingSlider;
    public TextMeshProUGUI LoadingProgressTxt;

    //https://docs.unity3d.com/ScriptReference/AsyncOperation.html
    private AsyncOperation m_AsyncOperation;

    private void Awake()
    {
        LogoAnim.gameObject.SetActive(true);
        Title.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(LoadGameCo());
    }

    private IEnumerator LoadGameCo()
    {
        Logger.Log($"{GetType()}::LoadGameCo");

        LogoAnim.Play();
        yield return new WaitForSeconds(LogoAnim.clip.length);

        LogoAnim.gameObject.SetActive(false);
        Title.SetActive(true);

        m_AsyncOperation = SceneLoader.Instance.LoadSceneAsync(SceneType.Lobby);
        if(m_AsyncOperation == null)
        {
            Logger.Log("Lobby async loading error.");
            yield break;
        }

        m_AsyncOperation.allowSceneActivation = false;

        /*
        * 로딩 시간이 짧은 경우 로딩 슬라이더 변화가 너무 빨라 보이지 않을 수 있다.
        * 일부러 몇 초 간 50%로 보여줌으로써 시각적으로 더 자연스럽게 처리한다.
        */
        LoadingSlider.value = 0.5f;
        LoadingProgressTxt.text = $"{(int)(LoadingSlider.value * 100)}%";
        yield return new WaitForSeconds(0.5f);

        while(!m_AsyncOperation.isDone) //로딩이 진행 중일 때 
        {
            //로딩 슬라이더 업데이트
            LoadingSlider.value = m_AsyncOperation.progress < 0.5f ? 0.5f : m_AsyncOperation.progress;
            LoadingProgressTxt.text = $"{(int)(LoadingSlider.value * 100)}%";

            //씬 로딩이 완료되었다면 로비로 전환하고 코루틴 종료
            if(m_AsyncOperation.progress >= 0.9f)
            {
                m_AsyncOperation.allowSceneActivation = true;
                yield break;
            }

            yield return null;
        }
    }
}
