using System;
using System.Collections;
using System.Collections.Generic;
using CUFramework.Custom;
using CUFramework.Entry;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    
    public Button btn_increase;
    public Button btn_decrease;
    public Button btn_haptic;
    public Button btn_notification;
    public TMP_Text text;
    public TMP_Text versionText;

    public Transform liquid;

    private Renderer _renderer;

    private MaterialPropertyBlock _materialProperty;

    // Start is called before the first frame update
    private float _fillAmount = 0.5f;
    private static readonly int FillAmount = Shader.PropertyToID("_Fill");

    private void Awake()
    {
        _renderer = liquid.GetComponent<Renderer>();
        _materialProperty = new MaterialPropertyBlock();
        CU.Audio.Music.Play(MusicKey.Background);
        versionText.text = $"Version: {Application.version}";
    }

    private void OnEnable()
    {
        CU.Event.Add<float>("LiquidChange", OnLiquidChange);
        btn_decrease.onClick.AddListener(() =>
        {
            CU.Audio.PlayUI(UIKey.Click);
            CU.Event.Dispatch("LiquidChange", -0.1f);
        });
        
        btn_increase.onClick.AddListener(() =>
        {
            CU.Audio.PlayEffect(EffectKey.FootStep);
            CU.Event.Dispatch("LiquidChange", 0.1f);
        });
        btn_haptic.onClick.AddListener(() =>
        {
            CU.Audio.Music.Pause();
            SceneManager.LoadScene(2);
        });
        btn_notification.onClick.AddListener(() =>
        {
            CU.Audio.Music.Pause();
            SceneManager.LoadScene(3);
        });
    }

    private void OnDisable()
    {
        CU.Event?.Remove<float>("LiquidChange", OnLiquidChange);
    }


    void Start()
    {
        _fillAmount = _renderer.sharedMaterial.GetFloat(FillAmount);

        UpdateText();
    }

    private void OnLiquidChange(float amount)
    {
        _fillAmount += amount;
        if (_fillAmount > 1f)
        {
            _fillAmount = 1f;
        }
        else if (Mathf.Approximately(_fillAmount, 0) || _fillAmount < 0f)
        {
            _fillAmount = 0f;
        }

        _materialProperty.SetFloat(FillAmount, _fillAmount);
        _renderer.SetPropertyBlock(_materialProperty);

        UpdateText();
    }

    private void UpdateText()
    {
        var percent = Mathf.RoundToInt(_fillAmount * 100);
        text.text = $"{percent}/100";
    }

    // Update is called once per frame
    void Update()
    {
    }
}