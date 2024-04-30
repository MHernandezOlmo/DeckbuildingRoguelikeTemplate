public interface IDamageReceiver
{
    int CurrentHealth { get; set; }
    int MaxHealth { get; set; }

    void ReceiveDamage(int amount);
}