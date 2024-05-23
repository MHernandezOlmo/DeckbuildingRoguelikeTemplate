using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AlterStatusEffect : IAlterStatusEffect
{
    public abstract void ApplyEffect(GameCharacter character);
}
