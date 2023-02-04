using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int spawnNodeNum;
    [SerializeField] private int endNodeNum;

    [SerializeField] private BaseSprite enemyType;

    [SerializeField] int spawnHealth = 1;
    [SerializeField] int spawnDamage = 1;

    [SerializeField] float movementSpeed = 0.4f;

    private void OnMouseDown()
    {
        Debug.LogWarning("***Implement Resource System For Spawning***");
        if (true)
        {
            GameObject firstNode = GameObject.Find("PathNode (" + spawnNodeNum + ")");
            BaseSprite instance = Instantiate(enemyType, firstNode.transform.position, Quaternion.identity);

            instance.setVariables(spawnHealth, spawnDamage, movementSpeed, spawnNodeNum, firstNode, endNodeNum);
        }
    }
}
