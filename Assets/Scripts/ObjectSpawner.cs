using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; 
    public Transform spawnPoint; 
    public int spawnCost = 100; 
    public GameObject notEnoughMoneyUI; 

    public void TrySpawnObject()
    {
        if (MoneyManager.Instance.SpendMoney(spawnCost)) 
        {
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            if (notEnoughMoneyUI != null)
            {
                notEnoughMoneyUI.SetActive(true); 
                Invoke(nameof(HideNotEnoughMoneyUI), 2f);
            }
        }
    }

    private void HideNotEnoughMoneyUI()
    {
        if (notEnoughMoneyUI != null)
        {
            notEnoughMoneyUI.SetActive(false); 
        }
    }
}
