using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject[] screenMessage;

    [SerializeField]
    private GameObject[] intoBlackHole;
    
    private void Awake()
    {
        DisableObj.OnFadeOutFinished += FadeOutFinished;
        TextManager.OnMessageFinished += MessageFinished;
    }

    private void MessageFinished()
    {
        foreach (var toDisable in screenMessage)
        {
            toDisable.SetActive(false);
        }

        foreach (var toEnable in intoBlackHole)
        {
            toEnable.SetActive(true);
        }
    }

    private void FadeOutFinished()
    {
        foreach (var toEnable in screenMessage)
        {
            toEnable.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        DisableObj.OnFadeOutFinished -= FadeOutFinished;
        TextManager.OnMessageFinished -= MessageFinished;
    }
}
