using System;

public class PlayerManager : Character
{
    private static int gold;

    public static Action<int> OnGoldUpdated;
    public static Action<int> OnHealthUpdated;
    public static Action<int> OnMaxHealthUpdated;
    public static Action OnPlayerDeath;

    private void Awake()
    {
        Gold.OnGoldPickedUp += GoldPickedUp;
    }

    private new void Start()
    {
        base.Start();

        // populate the UI
        OnGoldUpdated?.Invoke(gold);
        OnMaxHealthUpdated?.Invoke(maxHealth);
        OnHealthUpdated?.Invoke(currentHealth);
    }

    private void GoldPickedUp()
    {
        gold++;
        OnGoldUpdated?.Invoke(gold);
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        OnHealthUpdated?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //Player lost
    private void Die()
    {
        //gameObject.SetActive(false);
        OnPlayerDeath?.Invoke();
    }

    private void OnDestroy()
    {
        Gold.OnGoldPickedUp -= GoldPickedUp;
    }
}
