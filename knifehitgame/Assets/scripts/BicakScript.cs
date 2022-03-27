using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicakScript : MonoBehaviour
{
    public GameObject tekrarButton;
    [SerializeField] private AudioSource Audio;
    [SerializeField] private AudioClip woodHitEffect;
    [SerializeField] private AudioClip knifeHitEffect;
    [SerializeField] private AudioClip knifeThrowEffect;
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

            Audio.PlayOneShot(knifeThrowEffect);
            rb.AddForce(atisKuvveti, ForceMode2D.Impulse);
            rb.gravityScale = 1;
            GameController.Instance.GameUI.DecrementDisplayedKnifeCount();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (!isActive)
            return;

        isActive = false;


        if (collision.collider.tag == "Kutuk")
        {
            GetComponent<ParticleSystem>().Play();
            Audio.PlayOneShot(woodHitEffect);
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            bicakCollider.offset = new Vector2(bicakCollider.offset.x, -0.4f);
            bicakCollider.size = new Vector2(bicakCollider.size.x, 1.2f);
            GameController.Instance.OnSuccessfulKnifeHit(); 
        }
        else if (collision.collider.tag == "Bicak")
        {
            Audio.PlayOneShot(knifeHitEffect);
            rb.velocity = new Vector2(rb.velocity.x, -2);
            GameController.Instance.StartGameOverSequence(false);
            tekrarButton.SetActive(true);

        }
    }

}
