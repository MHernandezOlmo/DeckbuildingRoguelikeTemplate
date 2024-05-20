using UnityEngine;

public class GameCharactersController : MonoBehaviour
{
    [SerializeField] private HeroController _heroController;
    [SerializeField] private EnemiesBattleController _enemiesBattleController;

    public HeroController CurrentHeroController
    {
        get => _heroController;
        set
        {
            _heroController = value;
        }
    }
    public void InitializeCharacters()
    {
        _heroController.InitializeHero();
        _enemiesBattleController.InitializeEnemies();
    }
    
}