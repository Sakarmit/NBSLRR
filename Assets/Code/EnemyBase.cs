using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] int startingHealth;
    public int enemyBaseHealth = 100;
    [SerializeField] private TextMeshProUGUI enemyHealthDisplay;

    [SerializeField] private int[] spawnNodeNums;
    [SerializeField] private int[] endNodeNums;

    [SerializeField] private BaseSprite enemyType;
    [SerializeField] private GuiController GameUI;

    [SerializeField] int startEnemyHealth;
    public float spawnHealth;
    [SerializeField] int startEnemyDamage;
    public int spawnDamage;

    [SerializeField] float startSpeed;
    public float movementSpeed;

    [SerializeField] int maxEnemyCount = 14;
    [SerializeField] int spawnSpeed;
    [SerializeField] float HealthIncreaseRate;

    int spawnCooldown = 0;
    private void Start()
    {
        enemyBaseHealth = startingHealth;
        spawnHealth = startEnemyHealth;
        spawnDamage = startEnemyDamage;
        movementSpeed = startSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        if (enemyBaseHealth <= 0)
        {
            enemyHealthDisplay.text = enemyBaseHealth.ToString("0000.#");
            GameUI.GetComponent<GuiController>().SlideInEndScreen("You Win!");
        }
    }

    private void FixedUpdate()
    {
        if (spawnCooldown > spawnSpeed && GameObject.FindGameObjectsWithTag("BadSprites").Length < maxEnemyCount)
        {
            int randomPath = Random.Range(0, 5);
            GameObject firstNode = GameObject.Find("PathNode (" + spawnNodeNums[randomPath] + ")");
            BaseSprite instance = Instantiate(enemyType, firstNode.transform.position, Quaternion.identity);

            instance.setVariables(spawnHealth, spawnDamage, movementSpeed, 
                spawnNodeNums[randomPath], firstNode, endNodeNums[randomPath]);
            spawnCooldown = 0;
        } 
        else
        {
            spawnCooldown = Math.Clamp(spawnCooldown+1, 0, spawnSpeed+1);
        }
        enemyHealthDisplay.text = enemyBaseHealth.ToString("0000.#");
        spawnHealth += HealthIncreaseRate;
    }

    public void SetDefaults()
    {
        enemyBaseHealth = startingHealth;
        spawnHealth = startEnemyHealth;
        spawnDamage = startEnemyDamage;
        movementSpeed = startSpeed;
    }
}
