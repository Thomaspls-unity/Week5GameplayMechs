using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomisationInput : MonoBehaviour
{
    private CharacterManager characterManager;
    private int tempHeadValue;
    private int tempLegValue;

    private void Start()
    {
        characterManager = FindObjectOfType<CharacterManager>();
    }
    // Update is called once per frame
    void Update()
    {
        //For Head Value
        if (Input.GetKeyDown(KeyCode.A))
        {
            tempHeadValue = 0;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            tempHeadValue = 1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            tempHeadValue = 2;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            tempHeadValue = 3;
        }

        //For Leg Value
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            tempLegValue = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            tempLegValue = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            tempLegValue = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            tempLegValue = 3;
        }

        //Pressing Space here does the final application of the material
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characterManager.ApplyMaterialToCharacter(tempHeadValue, tempLegValue);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("SandboxGame");
        }
    }
}
