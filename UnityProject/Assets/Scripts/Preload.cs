using System;
using System.Collections;
using System.Collections.Generic;
using CUFramework.Core;
using CUFramework.Entry;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preload : MonoBehaviour
{
    private void Start()
    {
        
        CU.Timer.StartTimer(1f, i =>
        {
            SceneManager.LoadScene(1);
        });
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnRuntimeOnLoad()
    {
        Log.SetSetting(new LogSetting()
        {
            log2File = false,
            // categoryShow = LogCategoryShow.Game
        });
    }
}
