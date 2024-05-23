public class DamageReducerAlterStatusEffect : AlterStatusEffect
{
    public override void ApplyEffect(GameCharacter targetCharacter)
    {
        targetCharacter.AddDamageDecorator(new DamageModifierDecorator(-55));
    }
}