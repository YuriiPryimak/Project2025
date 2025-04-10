using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ind : MonoBehaviour
{
    public static Ind instance;

    public Image helthBar, foodBar;
    public float helthAmount = 100;
    public float foodAmount = 100;

    public float FoodBarAmountTime = 200f;
    public float HealthBarAmountTime = 120f;
    public float HealthRestoreRate = 20f;

    public int targetSceneIndex = 2;

    private float lastEatTime = 0f;
    private float eatCooldown = 0.5f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        if (helthBar != null) helthBar.fillAmount = helthAmount / 100;
        if (foodBar != null) foodBar.fillAmount = foodAmount / 100;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        if (Time.time - lastEatTime > eatCooldown)
        {
            if (foodAmount > 0)
            {
                foodAmount -= 100 / FoodBarAmountTime * Time.deltaTime;
            }
        }

        if (foodAmount <= 0)
        {
            helthAmount -= 100 / HealthBarAmountTime * Time.deltaTime;
        }

        if (foodAmount == 100 && helthAmount < 100)
        {
            helthAmount += HealthRestoreRate * Time.deltaTime;
            helthAmount = Mathf.Min(helthAmount, 100);
        }

        if (foodBar != null) foodBar.fillAmount = foodAmount / 100;
        if (helthBar != null) helthBar.fillAmount = helthAmount / 100;

        if (helthAmount <= 0)
        {
            LoadTargetScene();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    void LoadTargetScene()
    {
        if (targetSceneIndex >= 0 && targetSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(targetSceneIndex);
        }
    }

    public void IncreaseFood(float amount)
    {
        foodAmount = Mathf.Min(foodAmount + amount, 100);
        if (foodBar != null) foodBar.fillAmount = foodAmount / 100;
        lastEatTime = Time.time;
    }

  
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        helthBar = GameObject.FindWithTag("HealthBar")?.GetComponent<Image>();
        foodBar = GameObject.FindWithTag("FoodBar")?.GetComponent<Image>();

        if (helthBar != null) helthBar.fillAmount = helthAmount / 100;
        if (foodBar != null) foodBar.fillAmount = foodAmount / 100;
    }
}
