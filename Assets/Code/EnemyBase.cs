using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] public int enemyBaseHealth = 100;

    [SerializeField] private int[] spawnNodeNums;
    [SerializeField] private int[] endNodeNums;

    [SerializeField] private BaseSprite enemyType;
    [SerializeField] private GuiController GameUI;

    [SerializeField] int spawnHealth = 1;
    [SerializeField] int spawnDamage = 1;

    [SerializeField] float movementSpeed = 0.4f;

    [SerializeField] int maxEnemyCount = 14;

    public static bool gameStart = false;
    public static bool gameEnd = false;

    [SerializeField] private GameObject ExitButton;
    // Update is called once per frame
    void Update()
    {
        if (enemyBaseHealth <= 0 && !gameEnd)
        {
            gameEnd = true;
            GameUI.GetComponent<GuiController>().SlideInEndScreen();
            ExitButton.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (gameStart && !gameEnd && GameObject.FindGameObjectsWithTag("BadSprites").Length < maxEnemyCount)
        {
            int randomPath = Random.Range(0, 4);
            GameObject firstNode = GameObject.Find("PathNode (" + spawnNodeNums[randomPath] + ")");
            BaseSprite instance = Instantiate(enemyType, firstNode.transform.position, Quaternion.identity);

            instance.setVariables(spawnHealth, spawnDamage, movementSpeed, 
                spawnNodeNums[randomPath], firstNode, endNodeNums[randomPath]);
        }
    }
}
