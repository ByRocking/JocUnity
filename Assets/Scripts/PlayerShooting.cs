using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Camera cam;
    Vector2 mousePos;
    public Rigidbody2D rb;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 10f;

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    private void FixedUpdate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
