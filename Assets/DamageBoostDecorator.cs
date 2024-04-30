
using UnityEngine;

public class DamageBoostDecorator : IDamageDealer
{
    private IDamageDealer _wrappedDamageDealer;
    public int Damage { get; set; }

    public DamageBoostDecorator(IDamageDealer wrappedDamageDealer, int damage)
    {
        _wrappedDamageDealer = wrappedDamageDealer;
        Damage = damage;
    }
    public DamageBoostDecorator(int damage)
    {
        Damage = damage;
    }

    public void SetDamageDealerToBeWrapped(IDamageDealer wrappedDamageDealer)
    {
        _wrappedDamageDealer = wrappedDamageDealer;
    }

    public void DealDamage(IGameCharacter target, int amount)
    {
        Debug.Log($"ya de por sí yo haría {amount}");   
        _wrappedDamageDealer.DealDamage(target, amount + Damage);
    }

}