public class Artifact : StatusEffect
{
    private int counter;

    public Artifact(int counter)
    {
        this.counter = counter;
    }

    public override void ApplyEffect(IGameCharacter target)
    {
        
    }

    public override void RemoveEffect(IGameCharacter character)
    {
        
    }
}