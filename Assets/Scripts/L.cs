using UnityEngine;

public class L : MonoBehaviour
{
    public GameObject panel; 
    public float interactionDistance = 3f; 
    private Transform player; 
    private MoveMent playerMovement; 
    private CameraMove horizontalLook; 
    private CameraMove verticalLook;
    private Rigidbody playerRigidbody; 

    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }

       
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null)
        {
            playerMovement = player.GetComponent<MoveMent>();
            horizontalLook = player.GetComponent<CameraMove>();
            verticalLook = player.GetComponentInChildren<CameraMove>();
            playerRigidbody = player.GetComponent<Rigidbody>();
        }

       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (player != null && panel != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

           
            if (distance <= interactionDistance && Input.GetKeyDown(KeyCode.Q) && !panel.activeSelf)
            {
                OpenPanel();
            }
        }
    }

    public void OpenPanel()
    {
        if (panel == null) return;

        panel.SetActive(true);

       
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        if (horizontalLook != null)
        {
            horizontalLook.enabled = false;
        }

        if (verticalLook != null)
        {
            verticalLook.enabled = false;
        }

       
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.isKinematic = true;
        }

      
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ClosePanel()
    {
        if (panel == null || !panel.activeSelf) return;

        panel.SetActive(false);

        
        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }

        if (horizontalLook != null)
        {
            horizontalLook.enabled = true;
        }

        if (verticalLook != null)
        {
            verticalLook.enabled = true;
        }

       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = false;
        }
    }
}
