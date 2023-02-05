using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] public int playerBaseHealth = 50;

    [SerializeField] public float resource = 10;
    [SerializeField] public float resourceRate;

    //Counts how many loops of fixed update happened
    private int fixedUpdateCounter = 0;
    private void Update()
    {
        if (playerBaseHealth <= 0)
        {
            Debug.Log("***Implement Game Over Here***");
        } 
    }

    private void FixedUpdate()
    {
        if (fixedUpdateCounter == 60)
        {
            resource += resourceRate;
            fixedUpdateCounter = 0;
        }
        else
        {
            fixedUpdateCounter++;
        }

    }
}
