
using UnityEngine;

public class DamageModifierDecorator : IDamageDealer
{
    private IDamageDealer _wrappedDamageDealer;
    public int Damage { get; set; }

    public DamageModifierDecorator(IDamageDealer wrappedDamageDealer, int damage)
    {
        _wrappedDamageDealer = wrappedDamageDealer;
        Damage = damage;
    }
    public DamageModifierDecorator(int damage)
    {
        Damage = damage;
    }

    public void SetDamageDealerToBeWrapped(IDamageDealer wrappedDamageDealer)
    {
        _wrappedDamageDealer = wrappedDamageDealer;
    }

    public void DealDamage(GameCharacter target, int amount)
    {
        Debug.Log($"Modifico el daño que venia {amount} en " + Damage);
        _wrappedDamageDealer.DealDamage(target, amount + Damage);
    }

}