using System;

public class ActionEffect
{
    public Action Action { get; }
    public int RemainingUses { get; private set; }

    public ActionEffect(Action action, int uses)
    {
        Action = action;
        RemainingUses = uses;
    }

    public void Apply()
    {
        if (RemainingUses > 0)
        {
            Action.Invoke();
            RemainingUses--;
        }
    }

    public bool IsExpired()
    {
        return RemainingUses <= 0;
    }
}