using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BadSprite : BaseSprite
{
    [SerializeField] private float node = 99f;
    private GameObject targetNode;

    private float movementSpeed = 1f;

    private void Start()
    {
        targetNode = GameObject.Find("PathNode (" + node + ")");
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetNode.transform.position, Time.deltaTime * movementSpeed);
        if (transform.position == targetNode.transform.position)
        {
            if (node == 0)
            {
                Destroy(gameObject);
                Debug.LogWarning("***Insert Player Base Damage Here***");
            }
            targetNode = GameObject.Find("PathNode (" + --node + ")");
        }
    }
}
