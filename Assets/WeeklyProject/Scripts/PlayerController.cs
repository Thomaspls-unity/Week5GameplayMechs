using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject focalPoint;
    private Rigidbody playerRb;
    public float speed = 5.0f;

    public PowerUpType currentPowerUp = PowerUpType.None;
    public GameObject bulletPrefab;

    private bool hasPowerUp = false;

    private GameObject tempBullet;
    private Coroutine powerUpCountdown;
   
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        if (currentPowerUp == PowerUpType.ManyBullets && Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullets();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType;
            Destroy(other.gameObject);

            if (powerUpCountdown != null)
            {
                StopCoroutine(powerUpCountdown);
            }
            powerUpCountdown = StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        currentPowerUp = PowerUpType.None;
    }

    private void ShootBullets()
    {
        foreach (var enemy in FindObjectsOfType<FightingEnemy>())
        {
            tempBullet = Instantiate(bulletPrefab, transform.position + Vector3.up, Quaternion.identity);
            tempBullet.GetComponent<Bullet>().Shoot(enemy.transform);
        }
    }
}
