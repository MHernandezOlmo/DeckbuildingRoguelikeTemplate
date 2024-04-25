using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EffectsTestScruot : MonoBehaviour
{

    public void ApplyArtifactToAllCharacters()
    {
        List<GameCharacter> enemies = FindObjectOfType<EnemiesBattleController>().GetEnemies().ToList();
        EffectManager.Instance.ApplyEffect(new ActiveStatusEffect(StatusEffects.Artifact, 2),enemies);
    }
}
