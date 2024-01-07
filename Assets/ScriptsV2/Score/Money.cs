using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Money : MonoBehaviour
{
    public int moneyValue = 19;

    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Kevin"))
        {
            StartCoroutine(PlaySound());
            MoneyCounter.instance.ChangeCurrency(moneyValue);
            Score.instance.IncreaseScore(moneyValue);
        }
    }

    IEnumerator PlaySound()
    {
        source.Play();

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
