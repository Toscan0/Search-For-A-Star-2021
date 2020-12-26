using System;

public class Gold : PickUp
{
    public static Action OnGoldPickedUp;

    public override void PickMe()
    {
        OnGoldPickedUp?.Invoke();
        Destroy(gameObject);
    }
}