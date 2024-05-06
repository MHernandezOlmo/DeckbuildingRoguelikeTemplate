using UnityEngine;

public class GameCharactersController : MonoBehaviour
{
    [SerializeField] private HeroController _heroController;
    [SerializeField] private EnemiesBattleController _enemiesBattleController;
    
    public void InitializeCharacters()
    {
        _heroController.InitializeHero();
        _enemiesBattleController.InitializeEnemies();
    }
    
}