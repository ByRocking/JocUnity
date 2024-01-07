using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kentuky : MonoBehaviour
{
    public int bonus = 15;
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
        stats.BONUS_DMG += bonus;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.BONUS_DMG -= bonus;

        Destroy(gameObject);
    }
}
