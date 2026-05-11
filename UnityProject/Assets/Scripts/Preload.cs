using System;
using System.Collections;
using System.Collections.Generic;
using CUFramework.Entry;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Preload : MonoBehaviour
{
    private void Start()
    {
        CU.Timer.StartTimer(1f, i =>
        {
            SceneManager.LoadScene(1);
        });
    }
}
