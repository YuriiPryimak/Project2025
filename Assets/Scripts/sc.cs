using UnityEngine;
using UnityEngine.SceneManagement;

public class sc : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        //
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(1); 
        }
    }
}
