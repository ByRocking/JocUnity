using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : MonoBehaviour
{
    public float multiplier = 1.4f;
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
        stats.MOVEMENT_BASE_SPEED *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.MOVEMENT_BASE_SPEED /= multiplier;

        Destroy(gameObject);
    }
}
