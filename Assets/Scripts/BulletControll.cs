using System.Collections;
using UnityEngine;

public class BulletControll : MonoBehaviour
{
    public GameObject bullet;
    public Camera mainCamera;
    public Transform Spawnbullet;

    public float ShootForse;
    public float spread;
    public float shootCooldown = 1f;

    private bool canShoot = true;

    public AudioClip shootSound;
    public AudioClip reloadSound;
    private AudioSource audioSource;

    void Start()
    {

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
    }

    void Update()
    {

        if (Time.timeScale == 0f)
            return;

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!canShoot) return;


        StartCoroutine(ShootDelay());


        PlaySound(shootSound);


        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(10);


        Vector3 dirWithoutSpread = targetPoint - Spawnbullet.position;
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);


        GameObject currentBullet = Instantiate(bullet, Spawnbullet.position, Quaternion.identity);
        currentBullet.transform.forward = dirWithSpread.normalized;


        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * ShootForse, ForceMode.Impulse);


    }

    private IEnumerator ShootDelay()
    {
        canShoot = false;


        PlaySound(reloadSound);


        yield return new WaitForSeconds(shootCooldown);

        canShoot = true;

    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();

        }
        else
        {

        }
    }
}



