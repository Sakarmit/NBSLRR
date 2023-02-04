using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BadSprite : BaseSprite
{
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetNode.transform.position, Time.deltaTime * movementSpeed);
        if (transform.position == targetNode.transform.position)
        {
            if (currentNode == LastNode)
            {
                baseManager.playerBaseHealth -= this.damage * Mathf.CeilToInt(this.health / this.damage);
                Destroy(gameObject);
            }
            targetNode = GameObject.Find("PathNode (" + --currentNode + ")");
        }
    }
}
