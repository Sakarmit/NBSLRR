using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodSprite : BaseSprite
{
    [SerializeField] private float node = 0;
    [SerializeField] private float LastNode = 0;
    private GameObject targetNode;

    private float movementSpeed = 1f;

    private void Start()
    {
        targetNode = GameObject.Find("PathNode (" + node + ")");
    }
    private void FixedUpdate()
    {
        Debug.Log(gameObject.name);
        transform.position = Vector2.MoveTowards(transform.position, targetNode.transform.position, Time.deltaTime * movementSpeed);
        if (transform.position == targetNode.transform.position)
        {
            if (node == LastNode)
            {
                Destroy(gameObject);
                Debug.LogWarning("***Insert Ememy Base Damage Here***");
            }
            targetNode = GameObject.Find("PathNode (" + ++node + ")");
        }
    }
}
