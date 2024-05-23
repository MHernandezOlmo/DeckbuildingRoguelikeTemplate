public class DamageBoosterRelicEffect : RelicEffect
{
    public override void ApplyEffect(GameCharacter targetCharacter)
    {
        targetCharacter.AddDamageDecorator(new DamageModifierDecorator(20));
    }
}