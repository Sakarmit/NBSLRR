using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] public int playerBaseHealth = 50;
    [SerializeField] private TextMeshProUGUI playerHealthDisplay;

    public TextMeshProUGUI resourceDisplay;
    public int sunResource;
    [SerializeField] public int resourceRate;

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
            sunResource += resourceRate;
            fixedUpdateCounter = 0;
        }
        else
        {
            fixedUpdateCounter++;
        }
        resourceDisplay.text = sunResource.ToString("0000.#");
        playerHealthDisplay.text = playerBaseHealth.ToString("0000.#");
    }
}
