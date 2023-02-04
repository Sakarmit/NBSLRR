using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] public int enemyBaseHealth = 100;

    [SerializeField] private int[] spawnNodeNums;
    [SerializeField] private int[] endNodeNums;

    [SerializeField] private BaseSprite enemyType;

    [SerializeField] int spawnHealth = 1;
    [SerializeField] int spawnDamage = 1;

    [SerializeField] float movementSpeed = 0.4f;

    [SerializeField] int maxEnemyCount = 14;
    // Update is called once per frame
    void Update()
    {
        if (enemyBaseHealth <= 0)
        {
            Debug.Log("***Implement Win Here***");
        }
    }

    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("BadSprites").Length < maxEnemyCount)
        {
            int randomPath = Random.Range(0, 4);
            GameObject firstNode = GameObject.Find("PathNode (" + spawnNodeNums[randomPath] + ")");
            BaseSprite instance = Instantiate(enemyType, firstNode.transform.position, Quaternion.identity);

            instance.setVariables(spawnHealth, spawnDamage, movementSpeed, 
                spawnNodeNums[randomPath], firstNode, endNodeNums[randomPath]);
        }
    }
}
