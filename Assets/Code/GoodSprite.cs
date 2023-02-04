using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodSprite : BaseSprite
{
    public int health = 15;
    public int damage = 5;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("BadSprites"))
        {
            int enemyHealth = collision.gameObject.GetComponent<BadSprite>().health;
            int enemyDamage = collision.gameObject.GetComponent<BadSprite>().damage;

            int turnsToKillThis = Mathf.CeilToInt(this.health / enemyDamage);
            int turnsToKillEnemy = Mathf.CeilToInt(enemyHealth / this.damage);

            if (turnsToKillEnemy > turnsToKillThis)
            {
                collision.gameObject.GetComponent<BadSprite>().health -= (this.damage * turnsToKillThis);
                Destroy(gameObject);
            }
            else if(turnsToKillEnemy == turnsToKillThis)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else
            {
                this.health -= (enemyDamage * turnsToKillEnemy);
                Destroy(collision.gameObject);
            }
        }
    }
}
