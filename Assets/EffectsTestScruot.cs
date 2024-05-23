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
        //EffectManager.Instance.ApplyEffect(new ActiveStatusEffect(StatusEffects.Buff1, 2),enemies);
    }
    public void ApplyBuff2ToAllCharacters()
    {
        List<GameCharacter> enemies = FindObjectOfType<EnemiesBattleController>().GetEnemies().ToList();
        //EffectManager.Instance.ApplyEffect(new ActiveStatusEffect(StatusEffects.Buff2, 1),enemies);
    }
    public void ApplyBuff3ToAllCharacters()
    {
        List<GameCharacter> enemies = FindObjectOfType<EnemiesBattleController>().GetEnemies().ToList();
        //EffectManager.Instance.ApplyEffect(new ActiveStatusEffect(StatusEffects.Buff3, Random.Range(0,10)),enemies);
    }
    
    public void ApplyBuff4ToRandomCharacters()
    {
        List<GameCharacter> enemies = FindObjectOfType<EnemiesBattleController>().GetEnemies().ToList();
        int randomEnemy = Random.Range(0, enemies.Count);
        //EffectManager.Instance.ApplyEffect(new ActiveStatusEffect(StatusEffects.Buff4, Random.Range(0,10)),new List<GameCharacter>(){enemies[randomEnemy]});
    }
    
}
