using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    [SerializeField] private float speed = 10f;

    [SerializeField] private Transform spawnOffset;
    [SerializeField] private BuildHouse[] house;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3 (horizontalInput, 0f, verticalInput);
        transform.position += moveDirection * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            BuildHouse houseBuilt = Instantiate(house[Random.Range(0, house.Length)], spawnOffset.position, Quaternion.identity);
            houseBuilt.StartBuild();
        }
    }
}
