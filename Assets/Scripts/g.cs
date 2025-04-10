using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class g : MonoBehaviour
{
    public int sceneIndex = 1; // Номер сцени, на яку перейти
    public bool requireClick = true; // Чи потрібно клікати (чи просто навелось)

    private void Start()
    {
        // Якщо це кнопка — додаємо подію
        Button btn = GetComponent<Button>();
        if (btn != null && requireClick)
        {
            btn.onClick.AddListener(LoadTargetScene);
        }
    }

    // Метод, який викликається вручну або через EventTrigger
    public void LoadTargetScene()
    {
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogWarning("Невірний індекс сцени: " + sceneIndex);
        }
    }
}

