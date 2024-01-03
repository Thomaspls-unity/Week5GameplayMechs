using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject focalPoint;
    private GameObject enemy;
    public Rigidbody bulletRb;
    private Rigidbody playerRb;
    public float speed = 5.0f;
    public bool hasPower = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 lookDirection = (enemy.transform.position - transform.position).normalized;

        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        //if (hasPower == true && Input.GetKeyDown(KeyCode.Space))
        //{
        //    ShootBullets();
        //}
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("PowerUp"))
    //    {
    //        hasPower = true;
    //    }
    //}

    //private void ShootBullets()
    //{
    //    Instantiate (bulletRb, playerRb.transform);
    //}
}
