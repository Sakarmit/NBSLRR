using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSprite : MonoBehaviour
{
    public int health;
    public int damage;

    protected float movementSpeed;

    protected int currentNode = 0;
    protected GameObject targetNode;
    protected int LastNode = 0;

    public void setVariables(int initHealth, int initDamage, float initMovSpeed, 
        int initCurrNode, GameObject initTargNode, int initLastNode)
    {
        health = initHealth;
        damage = initDamage;
        movementSpeed = initMovSpeed;
        currentNode = initCurrNode;
        targetNode = initTargNode;
        LastNode = initLastNode;
    }
}
