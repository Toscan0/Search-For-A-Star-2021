using System;

public class Heart : PickUp
{
    public static Action OnHeartPickedUp;

    public override void PickMe()
    {
        OnHeartPickedUp?.Invoke();
        gameObject.SetActive(false);
    }
}