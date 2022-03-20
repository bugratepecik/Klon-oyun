using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicakScript : MonoBehaviour
{
    [SerializeField]
    private Vector2 atisKuvveti;

    private bool isActive = true;

    private Rigidbody2D rb;
    private BoxCollider2D bicakCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bicakCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            rb.AddForce(atisKuvveti, ForceMode2D.Impulse);
            rb.gravityScale = 1;
            //Todo; kullanýlabilir býçak sayýsý eklenecek
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive)
            return;

        isActive = false;

        if (collision.collider.tag == "Kutuk")
        {
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            bicakCollider.offset = new Vector2(bicakCollider.offset.x, -0.4f);
            bicakCollider.size = new Vector2(bicakCollider.size.x, 1.2f);
            // yeni býçak eklenecek 
        }
        else if (collision.collider.tag == "Bicak")
        {
            rb.velocity = new Vector2(rb.velocity.x, -2);

        }
    }

}
