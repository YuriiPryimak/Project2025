using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{

    public void ChangeScenes(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}