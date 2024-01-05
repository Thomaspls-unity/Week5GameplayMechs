using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    public bool condition;
    public int maxHealth;

    public GameObject[] cubePrefab;
    public int gridLength = 100;
    private int gridCenter;
    public int pyramidHeight = 8;
    // Start is called before the first frame update
    void Start()
    {
        //UseDoWhileLoop();
        gridCenter = gridLength / 2;
        for (int x = 0; x < gridLength; x++)
        {
            for (int z = 0; z < gridLength; z++)
            {
                if (IsEdge(x, z) || IsCenter(x, z))
                {
                    Instantiate(cubePrefab[Random.Range(0, cubePrefab.Length)], new Vector3(x, 0, z), Quaternion.identity);
                }
            }
        }
        SpawnPyramid(gridCenter, gridCenter);
    }

    private bool IsEdge(int x, int z)
    {
        return x == 0 || x == gridLength-1 || z == 0 || z == gridLength-1;
    }

    private  bool IsCenter(int x, int z)
    {
        return x == gridCenter && z == gridCenter;
    }

    public void SpawnPyramid(int gridCenterX, int gridCenterZ)
    {
        // Generate a pyramid made of stacked cubes using the borderCubePrefabs array
        int pyramidHeight = 8;
        for (int y = pyramidHeight - 1; y >= 0; y--)
        {
            // Loop through each row of the current layer (x-axis)
            for (int xIndex = gridCenterX - y; xIndex <= gridCenterX + y; xIndex++)
            {
                // Loop through each column of the current layer (z-axis)
                for (int zIndex = gridCenterZ - y; zIndex <= gridCenterZ + y; zIndex++)
                {
                    // Randomly choose an index from the borderCubePrefabs array
                    int randomIndex = Random.Range(0, cubePrefab.Length);

                    // Calculate the position of the current cube in the pyramid
                    // The x and z values are adjusted based on the current layer to create a pyramid shape
                    // The y value represents the height of the current layer
                    Vector3 cubePosition = new Vector3(xIndex, pyramidHeight - 1 - y, zIndex);

                    // Instantiate a cube at the calculated position with a random color
                    Instantiate(cubePrefab[randomIndex], cubePosition, Quaternion.identity);
                }
            }
        }
    }

    private void SpawnCubes(int x, int z)
    {
        if (x == 0 || z == 0 || x == 99 || z == 99)
        {
            Instantiate(cubePrefab[Random.Range(0, cubePrefab.Length)], new Vector3(x, 0, z), Quaternion.identity);
        }
        else
        {
            Instantiate(cubePrefab[Random.Range(1, cubePrefab.Length)], new Vector3(x, 1, z), Quaternion.identity);
        }
    }

    private void SpawnCubesAtRandom(int x, int z)
    {
        if (Random.value > 0.6)
        {
            Instantiate(cubePrefab[Random.Range(0, cubePrefab.Length)], new Vector3(x, 1, z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //UseWhileLoop();
    }

    private void UseWhileLoop()
    {
        while (maxHealth < 5)
        {
            Debug.Log("While loop is ongoing");
            maxHealth++; //Always have a way to exit the while loop, it is not an if statement, otherwise unity will crash.
        }
    }

    private void UseDoWhileLoop()
    {
        do
        {
            Debug.Log("Do something before the while loop starts");
            maxHealth++;
        } while (maxHealth < 5);
    }
}
