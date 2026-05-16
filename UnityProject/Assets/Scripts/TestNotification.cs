using System.Collections;
using System.Collections.Generic;
using CUFramework.Custom;
using CUFramework.Entry;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestNotification : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // public void VibrateCustom(HapticCustomData customData)
    // {
    //     
    // }
    

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
        CU.Notification.Test();
    }
    
    public void VibrateUnity() => CU.Haptic.VibrateUnity();

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
