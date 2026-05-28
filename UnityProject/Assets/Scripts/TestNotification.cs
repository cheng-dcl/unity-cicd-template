using System;
using System.Collections;
using System.Collections.Generic;
using CUFramework.Custom;
using CUFramework.Entry;
using CUFramework.Module.Notification;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestNotification : MonoBehaviour
{
    
    public Button btn_test0;
    public Button btn_test1;
    public Button btn_send;
    public Button btn_back;
    public TMP_InputField input_day;
    public TMP_InputField input_hour;
    public TMP_InputField input_minute;

    private void Awake()
    {
        btn_test0.onClick.AddListener(Test0);
        btn_test1.onClick.AddListener(Test1);
        btn_send.onClick.AddListener(Send);
        btn_back.onClick.AddListener(Back);
    }

    public void Test0()
    {
        CU.Notification.testAndroid = 0;
    }
    
    public void Test1()
    {
        CU.Notification.testAndroid = 1;
    }

    public void Send()
    {
        int day = string.IsNullOrEmpty(input_day.text) ? 0 : int.Parse(input_day.text);
        int hour = string.IsNullOrEmpty(input_hour.text) ? 0 : int.Parse(input_hour.text);
        int minute = string.IsNullOrEmpty(input_minute.text) ? 0 : int.Parse(input_minute.text);
        var notification = CU.Notification.notifications.Find(n => n.triggerType == NotificationTriggerType.Calendar);
        notification.day = day;
        notification.hour = hour;
        notification.minute = minute;
        CU.Notification.Test();
    }
    

    public void Back()
    {
        CU.Audio.Music.Play();
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
