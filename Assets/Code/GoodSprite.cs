using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodSprite : BaseSprite
{
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetNode.transform.position, Time.deltaTime * movementSpeed);
        if (transform.position == targetNode.transform.position)
        {
            if (currentNode == LastNode)
            {
                Destroy(gameObject);
                Debug.LogWarning("***Insert Ememy Base Damage Here***");
            }
            targetNode = GameObject.Find("PathNode (" + ++currentNode + ")");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If this collided with Enemy calculates which loses health and which dies
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
