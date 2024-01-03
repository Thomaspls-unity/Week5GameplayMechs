using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingEnemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRb;
    private bool isAttacking = false;
    public float speed;

    [SerializeField] private float attackSpeed;
    [SerializeField] private float playerDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if ((Vector3.Distance(transform.position, player.transform.position) < playerDistance) && isAttacking == false)
        {
            //Enemy aggression against player
            Attack();
        }
    }

    public void Attack()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        if (isAttacking == false)
        {
            enemyRb.AddForce(lookDirection * attackSpeed, ForceMode.Impulse);
            isAttacking = true;
        }
    }
}
