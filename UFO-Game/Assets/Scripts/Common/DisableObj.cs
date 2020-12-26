using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObj : MonoBehaviour
{
    public static Action OnFadeOutFinished;

    public void SelfDisable()
    {
        gameObject.SetActive(false);

        OnFadeOutFinished?.Invoke();
    }
}
