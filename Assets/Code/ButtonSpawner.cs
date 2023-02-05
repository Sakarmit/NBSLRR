using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonSpawner : MonoBehaviour
{
    [SerializeField] int resourceCost = 1;

    [SerializeField] private int spawnNodeNum;
    [SerializeField] private int endNodeNum;

    [SerializeField] private BaseSprite spriteType;

    [SerializeField] float startingHealth;
    float spawnHealth = 1;
    [SerializeField] float startingDamage;
    float spawnDamage = 1;

    [SerializeField] float movementSpeed = 0.4f;

    [SerializeField] PlayerBase playerBase;

    [SerializeField] float DamageIncrease = 0.3f;
    [SerializeField] float HealthIncrease = 0.3f;

    string inputKey;
    private void Start()
    {
        spawnHealth = startingHealth; ;
        spawnDamage = startingDamage;
        inputKey = (1 + (spawnNodeNum / 10)).ToString();
    }
    private void Update()
    {
        if (Input.GetKeyDown(inputKey))
        {
            this.OnMouseDown();
        }
    }
    private void OnMouseDown()
    {
        if (playerBase.sunResource >= resourceCost)
        {
            spawnDamage += DamageIncrease;
            spawnHealth += HealthIncrease;
            GetComponent<ButtonController>().PlayButtonSound();
            playerBase.sunResource -= resourceCost;
            GameObject firstNode = GameObject.Find("PathNode (" + spawnNodeNum + ")");
            BaseSprite instance = Instantiate(spriteType, firstNode.transform.position, Quaternion.identity);

            instance.setVariables(spawnHealth, spawnDamage, movementSpeed, spawnNodeNum, firstNode, endNodeNum);
        }
    }

    private void SetDefaults()
    {
        spawnDamage = startingDamage;
        spawnHealth = startingHealth;
    }
}
