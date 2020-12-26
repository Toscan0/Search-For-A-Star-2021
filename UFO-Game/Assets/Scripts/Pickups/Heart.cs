using System;
using UnityEngine;

public class Heart : PickUp
{
    public static Action<int> OnHeartPickedUp;

    [SerializeField]
    private int value = 5;

    public override void PickMe()
    {
        OnHeartPickedUp?.Invoke(value);
        Destroy(gameObject);
    }
}