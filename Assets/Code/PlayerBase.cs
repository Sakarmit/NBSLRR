using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] int startingHealth;
    public int playerBaseHealth;
    [SerializeField] private TextMeshProUGUI playerHealthDisplay;

    public TextMeshProUGUI resourceDisplay;
    public int sunResource;
    [SerializeField] int startingSunRate;
    public int resourceRate;

    [SerializeField] private GuiController GameUI;
    //Counts how many loops of fixed update happened
    private int fixedUpdateCounter = 0;

    private void Start()
    {
        SetDefaults();
    }
    private void Update()
    {
        if (playerBaseHealth <= 0)
        {
            playerHealthDisplay.text = playerBaseHealth.ToString("0000.#");
            GameUI.GetComponent<GuiController>().SlideInEndScreen("You Lose");
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

    public void SetDefaults()
    {
        playerBaseHealth = startingHealth;
        sunResource = 0;
        resourceRate = startingSunRate;
    }
}
