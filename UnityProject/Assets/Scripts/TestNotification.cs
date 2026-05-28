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
    

    public Button btn_send;
    public Button btn_back;
    public Button btn_cancel;
    public Button btn_openSetting;
    public TMP_InputField input_day;
    public TMP_InputField input_hour;
    public TMP_InputField input_minute;
    
    private void Awake()
    {

        btn_send.onClick.AddListener(Send);
        btn_back.onClick.AddListener(Back);
        btn_cancel.onClick.AddListener(Cancel);
        btn_openSetting.onClick.AddListener(OpenSetting);
    }



    public void Send()
    {
        var day = string.IsNullOrEmpty(input_day.text) ? 0 : int.Parse(input_day.text);
        var hour = string.IsNullOrEmpty(input_hour.text) ? 0 : int.Parse(input_hour.text);
        var minute = string.IsNullOrEmpty(input_minute.text) ? 0 : int.Parse(input_minute.text);
        var notification = CU.Notification.datas.Find(n => n.triggerType == NotificationTriggerType.Calendar);
        notification.day = day;
        notification.hour = hour;
        notification.minute = minute;
        
        foreach (var notificationData in CU.Notification.datas)
        {
            CU.Notification.ScheduleNotification(notificationData);;
        }
    }
    

    public void Back()
    {
        CU.Audio.Music.Play();
        SceneManager.LoadScene(1);
    }
    
    public void Cancel()
    {
        CU.Notification.CancelAllNotifications();

    }
    
    public void OpenSetting()
    {
        CU.Notification.OpenNotificationSettings();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
