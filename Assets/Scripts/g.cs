using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class g : MonoBehaviour
{
    public int sceneIndex = 1; // ����� �����, �� ��� �������
    public bool requireClick = true; // �� ������� ������ (�� ������ ��������)

    private void Start()
    {
        // ���� �� ������ � ������ ����
        Button btn = GetComponent<Button>();
        if (btn != null && requireClick)
        {
            btn.onClick.AddListener(LoadTargetScene);
        }
    }

    // �����, ���� ����������� ������ ��� ����� EventTrigger
    public void LoadTargetScene()
    {
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogWarning("������� ������ �����: " + sceneIndex);
        }
    }
}

