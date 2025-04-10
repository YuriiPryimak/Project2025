using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Автоматичні посилання")]
    public Ind indicators;
    public MoneyManager moneyManager;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        FindReferences(); // пошук одразу при запуску
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindReferences(); // пошук після кожної зміни сцени
    }

    private void FindReferences()
    {
        if (indicators == null)
        {
            indicators = FindObjectOfType<Ind>();
            Debug.Log("Ind знайдено: " + (indicators != null));
        }

        if (moneyManager == null)
        {
            moneyManager = FindObjectOfType<MoneyManager>();
            Debug.Log("MoneyManager знайдено: " + (moneyManager != null));
        }
    }

    public void IncreaseFood(float amount)
    {
        if (indicators != null)
        {
            indicators.IncreaseFood(amount);
        }
    }

    public void AddMoney(int amount)
    {
        if (moneyManager != null)
        {
            moneyManager.AddMoney(amount);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
