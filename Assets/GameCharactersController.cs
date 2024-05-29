using UnityEngine;

public class GameCharactersController : MonoBehaviour
{
    [SerializeField] private EnemiesBattleController _enemiesBattleController;
    
    public void InitializeCharacters()
    {
        HeroController.Instance.InitializeHero();
        _enemiesBattleController.InitializeEnemies();
    }
    
}