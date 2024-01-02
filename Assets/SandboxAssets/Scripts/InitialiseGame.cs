using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseGame : MonoBehaviour
{
    public GameObject playerPrefab;
    private CharacterManager characterManager;
    // Start is called before the first frame update
    void Start()
    {
        characterManager = FindObjectOfType<CharacterManager>();
        Instantiate(playerPrefab);
        characterManager.ApplyMaterialToCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
