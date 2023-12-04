using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private int startingLives = 3;
    [SerializeField] private int scoreForExtraLife = 10000;
    [SerializeField] private int maxScore = 99990;
    [SerializeField] private float respawnDelay = 2.0f;

    [HideInInspector] public GameObject PlayerInstance { get; private set; }
    [HideInInspector] public Vector3 PlayerPosition => PlayerInstance.transform.position;

    private int currentScore;
    private int currentLives;
    private int scoreForNextExtraLife;

    public int Score
    {
        get => currentScore;
        private set
        {
            currentScore = Mathf.Min(value, maxScore);
            UIManager.Instance.UpdateScore(currentScore);
            CheckForExtraLife();
        }
    }

    public int Lives
    {
        get => currentLives;
        private set
        {
            currentLives = value;
            UIManager.Instance.UpdateLives(currentLives);
            if (currentLives <= 0) GameOver();
        }
    }

    #region Singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        Score = 0;
        Lives = startingLives;
        scoreForNextExtraLife = scoreForExtraLife;
        SpawnPlayer();
        Spawner.Instance.StartNewLevel();
    }

    public void AddScore(int scoreValue)
    {
        Score += scoreValue;
    }

    private void CheckForExtraLife()
    {
        if (Score >= scoreForNextExtraLife)
        {
            Lives++;
            scoreForNextExtraLife += scoreForExtraLife;
        }
    }

    public void PlayerDestroyed()
    {
        Lives--;
        if (Lives > 0) Invoke(nameof(SpawnPlayer), respawnDelay);
        else PlayerInstance = null; // Clear reference when out of lives
    }

    private void SpawnPlayer()
    {
        PlayerInstance = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }

    private void GameOver()
    {
        UIManager.Instance.ShowGameOverScreen();
    }
}
