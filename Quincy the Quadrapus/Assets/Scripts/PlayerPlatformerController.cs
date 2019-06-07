using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public ParticleSystem particleSystem;
    private bool doubleAvailable;
    private BoxCollider2D col;
    private bool hitEnemy;

    // Use this for initialization
    void Awake () 
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();    
        animator = GetComponent<Animator> ();
        doubleAvailable = true;
        col = GetComponent<BoxCollider2D>();
        hitEnemy = false;
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");
        if (move.x != 0f && this.transform.parent != null)
        {
            this.velocity.x = 0f;
            this.transform.parent = null;
        }
        if (Input.GetButtonDown ("Jump") && grounded) {
            velocity.y = jumpTakeOffSpeed;
            if (this.transform.parent != null) {
                this.transform.parent = null;
            }
        } 
        else if (Input.GetButtonDown("Jump") && doubleAvailable) {
            velocity.y = jumpTakeOffSpeed;
            particleSystem.Clear();
            particleSystem.transform.position = new Vector3(transform.position.x, transform.position.y, 3.0f);
            particleSystem.Play();
            doubleAvailable = false;
        }
        else if (Input.GetButtonUp ("Jump")) 
        {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }
        
        if (hitEnemy) {
            velocity.y = .9f * jumpTakeOffSpeed;
            hitEnemy = false;
        }

        if (!doubleAvailable && grounded) {
            doubleAvailable = true;
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < -0.01f));
        if (flipSprite) 
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        
        animator.SetBool ("grounded", grounded);
        animator.SetFloat ("velocityX", Mathf.Abs (move.x) / maxSpeed);
        animator.SetFloat ("velocityY", velocity.y);

        targetVelocity = move * maxSpeed;
    }

    public bool setHitEnemy(bool val) {
        if (velocity.y < 0) {
            hitEnemy = val;
            return true;
        }
        else return false;

    }
}