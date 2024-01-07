using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0f, 0f);
    public GameObject kevin;
    public Vector2 offset = new Vector2(0f, 0f);
    public GameObject hitEffect;

    public int damage = 20;

    private void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPosition = currentPosition + velocity * Time.deltaTime;

        Debug.DrawLine(currentPosition + offset, newPosition + offset, Color.red);

        RaycastHit2D[] hits = Physics2D.LinecastAll(currentPosition + offset, newPosition + offset);

        foreach(RaycastHit2D hit in hits)
        {
            GameObject other = hit.collider.gameObject;
            if (other.CompareTag("Money") || other.CompareTag("Furniture") || other.CompareTag("Barriers") || other.CompareTag("PowerUps"))
            {
            }
            else if (other != kevin)
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 0.4f);
                if (other.CompareTag("Mob"))
                {
                    Destroy(gameObject);
                    Debug.Log(other.name);
                    other.GetComponent<Enemy>().TakeDamage(damage);

                    break;
                }
                if (other.CompareTag("Walls"))
                {
                    Destroy(gameObject);
                    break;
                }
            }
        }

        transform.position = newPosition;
    }

    public void Init(int bonusDamage)
    {
        this.damage += bonusDamage;
    }
}
