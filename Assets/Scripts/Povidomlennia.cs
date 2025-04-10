using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Povidomlennia : MonoBehaviour
{
    public GameObject messagePrefab; 
    public Transform canvasTransform; 
    public Button jobDirectionButton; 
    public AudioClip notificationSound; 
    public AudioSource audioSource; 

    private GameObject currentMessage; 
    private bool isMessageActive = false; 

    private void Start()
    {
        if (jobDirectionButton != null)
        {
            jobDirectionButton.onClick.AddListener(StartJobDirection);
        }
    }

    public void StartJobDirection()
    {
        if (!isMessageActive)
        {
            float randomTime = Random.Range(3f, 10f);
            Invoke(nameof(ShowMessage), randomTime);
        }
    }

    private void ShowMessage()
    {
        if (isMessageActive) return;

       
        currentMessage = Instantiate(messagePrefab, canvasTransform);
        RectTransform messageRect = currentMessage.GetComponent<RectTransform>();

        
        messageRect.anchorMin = new Vector2(1, 0); 
        messageRect.anchorMax = new Vector2(1, 0); 
        messageRect.pivot = new Vector2(1, 0);     
        messageRect.anchoredPosition = new Vector2(-50, 50);

       
        if (audioSource != null && notificationSound != null)
        {
            audioSource.PlayOneShot(notificationSound);
        }

       
        Button messageButton = currentMessage.GetComponent<Button>();
        if (messageButton != null)
        {
            messageButton.onClick.AddListener(OnMessageClicked);
        }

        isMessageActive = true;
    }

    private void OnMessageClicked()
    {
        if (currentMessage != null)
        {
            Destroy(currentMessage);
            isMessageActive = false;
            SceneManager.LoadScene(2); 
        }
    }
}
