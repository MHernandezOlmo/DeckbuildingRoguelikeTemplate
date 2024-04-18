using JetBrains.Annotations;
using UnityEngine;

public class GameDataController : MonoBehaviour
{
    private static GameDataController _instance;

    [SerializeField] private ScriptableObjectCharacterRepository _characterRepository;
    [SerializeField] private ScriptableObjectRelicsRepository _relicRepository;
    [SerializeField] private ScriptableObjectBattleRoomRepository _battleRoomRepository;
    [SerializeField] private ScriptableObjectEnemyRespository _enemyRespository;

    public ScriptableObjectCharacterRepository CharacterRepository => _characterRepository;
    public ScriptableObjectRelicsRepository RelicRepository => _relicRepository;
    public ScriptableObjectBattleRoomRepository BattleRoomRepository => _battleRoomRepository;
    public ScriptableObjectEnemyRespository EnemyRespository => _enemyRespository;


    public static GameDataController Instance
    {
        get
        {
            if (_instance == null)
            {
                GameDataController prefab = Resources.Load<GameDataController>("GameDataController");
                if(prefab!=null)
                {
                    _instance = Instantiate(prefab);
                }
            }

            return _instance;
        }
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
}