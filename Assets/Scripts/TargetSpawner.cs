using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; 
    public Transform[] spawnPoints;
    public float respawnTime = 3f; 
    private Dictionary<Transform, bool> activeTargets = new Dictionary<Transform, bool>();

    void Start()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            SpawnTarget(spawnPoint);
        }
    }

    void SpawnTarget(Transform spawnPoint)
    {
        if (!activeTargets.ContainsKey(spawnPoint) || !activeTargets[spawnPoint])
        {
            GameObject target = Instantiate(targetPrefab, spawnPoint.position, spawnPoint.rotation);
            Target targetScript = target.AddComponent<Target>();
            targetScript.spawner = this;
            targetScript.spawnPoint = spawnPoint;
            activeTargets[spawnPoint] = true;
        }
    }

    public void TargetHit(Transform spawnPoint)
    {
        activeTargets[spawnPoint] = false;
        StartCoroutine(RespawnTarget(spawnPoint));
    }

    IEnumerator RespawnTarget(Transform spawnPoint)
    {
        yield return new WaitForSeconds(respawnTime);
        SpawnTarget(spawnPoint);
    }
}

public class Target : MonoBehaviour
{
    public TargetSpawner spawner;
    public Transform spawnPoint;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) 
        {
            spawner.TargetHit(spawnPoint);
            Destroy(gameObject);
        }
    }
}

