using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingProjectile : MonoBehaviour
{
    public float speed = 5f;
    public ParticleSystem particle;
    public AudioSource explosionSound;
    
    protected Rigidbody2D rb;
    private Collider2D col;
    private SpriteRenderer spr;

    protected Transform target;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        spr = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        AimAtTarget(target);

        Moving();
    }

    public virtual void Moving()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePostDestroy();
            Destroy(gameObject, 1f);
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            HighScore.score++;
            HandlePostDestroy();
            Destroy(gameObject, 1f);
        }
    }

    private void HandlePostDestroy()
    {
        col.enabled = false;
        spr.enabled = false;
        explosionSound.Play();
        particle.Play();
    }

    public virtual void AimAtTarget(Transform target)
    {
        Vector2 targetDirection = transform.position - target.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }
}
