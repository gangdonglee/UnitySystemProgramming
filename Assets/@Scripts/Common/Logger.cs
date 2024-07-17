using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// 1. 추가적인 정보 표현 (ex. 타임스탬프)
// 2. 출시용 빌드를 위한 로그 제거
public static class Logger 
{
    [Conditional("DEV_VER")]
    public static void Log(string msg)
    {
        UnityEngine.Debug.LogFormat("{0} {1}", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg);
    }
    [Conditional("DEV_VER")]
    public static void LogWarning(string msg)
    {
        UnityEngine.Debug.LogFormat("{0} {1}", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg);
    }
    [Conditional("DEV_VER")]
    public static void LogError(string msg)
    {
        UnityEngine.Debug.LogFormat("{0} {1}", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg);
    }
}
