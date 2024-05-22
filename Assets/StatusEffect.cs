public abstract class StatusEffect : IStatusEffect
{
    public abstract void ApplyEffect(IGameCharacter target);

    public abstract void RemoveEffect(IGameCharacter character);
}