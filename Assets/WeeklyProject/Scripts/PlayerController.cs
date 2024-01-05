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
    public GameObject powerupIndicator;

    private bool hasPowerUp = false;

    private GameObject tempBullet;
    private float powerUpStrength = 16.0f;
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

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (currentPowerUp == PowerUpType.ManyBullets && Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullets();
        }

        if (transform.position.y < -5)
        {
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);

            if (powerUpCountdown != null)
            {
                StopCoroutine(powerUpCountdown);
            }
            powerUpCountdown = StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        currentPowerUp = PowerUpType.None;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void ShootBullets()
    {
        foreach (var enemy in FindObjectsOfType<FightingEnemy>())
        {
            tempBullet = Instantiate(bulletPrefab, transform.position + Vector3.up, Quaternion.identity);
            tempBullet.GetComponent<Bullet>().Shoot(enemy.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp && currentPowerUp == PowerUpType.BigHitter)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRigidBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}
