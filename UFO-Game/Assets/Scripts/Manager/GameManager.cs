using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsFadeOutFinished { get; private set; } = false;

    private void Awake()
    {
        DisableObj.OnFadeOutFinished += FadeOutFinished;
    }

    private void FadeOutFinished()
    {
        IsFadeOutFinished = true;
    }

    private void OnDestroy()
    {
        DisableObj.OnFadeOutFinished -= FadeOutFinished;
    }
}
