using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Character attributes:")]
    public float MOVEMENT_BASE_SPEED;
    public float ARROW_BASE_SPEED;
    public int MAX_HEALTH;
    public int BONUS_DMG = 0;

    [Space]
    [Header("Character statistics:")]
    public Vector2 movementDirection;
    public float movementSpeed;
    public bool endOfAiming;
    public int currentHealth;

    [Space]
    [Header("References:")]
    public Rigidbody2D rb;
    public Transform crostransform;
    public Animator animator;
    public GameObject crosshair;
    public Camera cam;
    public HealthBar healthBar;
    public GameObject deathEffect;
    public AudioSource source;

    [Space]
    [Header("Prefabs:")]
    public GameObject arrowPrefab;
    [Space]

    public bool isDead = false;

    void Start()
    {
        currentHealth = MAX_HEALTH;
        healthBar.SetMaxHealth(MAX_HEALTH);
        Cursor.visible = false;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isDead)
        {
            ProcessInputs();
            Move();
            Shoot();
            Animate();
        }
            
    }

    private void FixedUpdate()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        crostransform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0f, 1f);
        movementDirection.Normalize();

        endOfAiming = Input.GetButtonDown("Fire1");
    }

    void Move()
    {
        rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }

    void Animate()
    {
        if (movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        animator.SetFloat("Speed", movementSpeed);
    }

    void Shoot()
    {
        Vector2 shootingDirection = crosshair.transform.localPosition;
        shootingDirection.Normalize();

        if (endOfAiming)
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            Arrow arrowScript = arrow.GetComponent<Arrow>();
            arrowScript.Init(BONUS_DMG);
            Vector3 direction = crostransform.position - transform.position;
            direction.Normalize();
            arrowScript.GetComponent<Arrow>().velocity = direction * ARROW_BASE_SPEED;
            arrowScript.kevin = gameObject; 
            Destroy(arrow, 2f);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Mob"))
        {
            TakeDamage(13);
            StartCoroutine(PlaySound());
            Vector2 pulse = new Vector2(Mathf.Min(collision.relativeVelocity.x, 1), Mathf.Min(collision.relativeVelocity.y, 1));
            collision.rigidbody.AddForce(-pulse * 100);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    
        healthBar.SetHealth(currentHealth);
    
        if (currentHealth <= 0)
        {
            isDead = true;
            Die();
        }
    }

    IEnumerator PlaySound()
    {
        source.Play();

        yield return new WaitForSeconds(1f);
    }

    void Die()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        var comps = GetComponentsInChildren<SpriteRenderer>();
        foreach (var comp in comps)
            comp.enabled = false;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.9f);
        FindObjectOfType<GameManager>().EndGame();
    }
}
