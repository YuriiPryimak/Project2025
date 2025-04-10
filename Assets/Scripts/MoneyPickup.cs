using UnityEngine;

public class MoneyPickup : MonoBehaviour
{
    public int moneyValue = 100; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            MoneyManager.Instance.AddMoney(moneyValue); 
            Destroy(gameObject); 
        }
    }
}

