using System.Collections;
using System.Collections.Generic;
using CUFramework.Custom;
using CUFramework.Entry;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestHaptic : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // public void VibrateCustom(HapticCustomData customData)
    // {
    //     
    // }
    public void Vibrate() => CU.Haptic.Vibrate();
    public void Light() => CU.Haptic.Light();
    public void Medium() => CU.Haptic.Medium();
    public void Heavy() => CU.Haptic.Heavy();
    public void Soft() => CU.Haptic.Soft();
    public void Rigid() => CU.Haptic.Rigid();
    public void Success() => CU.Haptic.Success();
    public void Warning() => CU.Haptic.Warning();
    public void Error() => CU.Haptic.Failure();

    public void Selection()
    {
        CU.Audio.PlayUI(UIKey.Click);
        CU.Haptic.Selection();
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
