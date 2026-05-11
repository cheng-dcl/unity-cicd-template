using System;
using UnityEngine;

public class TestDefine : MonoBehaviour
{
    void Awake()
    {
#if TEST_RSP
        Debug.Log("TEST_RSP");
#else
        Debug.Log("TEST_RSP not defined");
#endif
#if TEST_RSP2
        Debug.Log("TEST_RSP2");
#else
        Debug.Log("TEST_RSP2 not defined");
#endif
    }

    private void Start()
    {
#if CU_MODULE_PUB
        Debug.Log("CU_MODULE_PUB");
#else
        Debug.Log("CU_MODULE_PUB not defined");
#endif

#if CU_MODULE_HAPTIC
        Debug.Log("CU_MODULE_HAPTIC");
#else
        Debug.Log("CU_MODULE_HAPTIC not defined");
#endif
        
#if CU_CUSTOM_ENABLED
        Debug.Log("CU_CUSTOM_ENABLED");
#else
        Debug.Log("CU_CUSTOM_ENABLED not defined");
#endif
    }
}