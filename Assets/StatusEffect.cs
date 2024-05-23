public abstract class StatusEffect : IStatusEffect
{
    public abstract void ApplyEffect(GameCharacter target);

    public abstract void RemoveEffect(GameCharacter character);
}