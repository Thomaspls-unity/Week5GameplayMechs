using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Material[] materialsHead;
    public Material[] materialsLeg;

    private int headNumberSaved;
    private int legNumberSaved;

    private PlayerCustomisation playerCustomisation;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        playerCustomisation = FindObjectOfType<PlayerCustomisation>();
    }

    public void ApplyMaterialToCharacter(int headNumber = 0, int legNumber = 0) //The 0s are the default
    {
        headNumberSaved = headNumber;
        legNumberSaved = legNumber;
        playerCustomisation.SetPlayerCustomisation(materialsHead[headNumber], materialsLeg[legNumber]);
    }

    public void ApplyMaterialToCharacter()
    {
        if (playerCustomisation == null)
        {
            playerCustomisation = FindObjectOfType<PlayerCustomisation>();
        }
        playerCustomisation.SetPlayerCustomisation(materialsHead[headNumberSaved], materialsLeg[legNumberSaved]);
    }
}
