using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// 1. �߰����� ���� ǥ�� (ex. Ÿ�ӽ�����)
// 2. ��ÿ� ���带 ���� �α� ����
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
