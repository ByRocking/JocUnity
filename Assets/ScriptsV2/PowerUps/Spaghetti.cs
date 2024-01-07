using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaghetti : MonoBehaviour
{
    public float multiplier = 1.5f;
    public float duration = 10f;

    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kevin"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        source.Play();

        PlayerController stats = player.GetComponent<PlayerController>();
        stats.MAX_HEALTH = (int)(stats.MAX_HEALTH * multiplier);
        stats.currentHealth = stats.MAX_HEALTH;
        stats.TakeDamage(0);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.MAX_HEALTH = (int)(stats.MAX_HEALTH / multiplier);
        if (stats.currentHealth > stats.MAX_HEALTH)
        {
            stats.currentHealth = stats.MAX_HEALTH;
            stats.TakeDamage(0);
        }

        Destroy(gameObject);
    }
}
