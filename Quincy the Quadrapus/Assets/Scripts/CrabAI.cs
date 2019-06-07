using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabAI : PhysicsObject
{
    private bool movingLeft;
    private Rigidbody2D rigidbody;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        movingLeft = true;
    }

    // Update is called once per frame
    protected override void ComputeVelocity()
    {
        if (velocity.x == 0f) {
            movingLeft = !movingLeft;
            render.flipX = !render.flipX;
        }
        if (movingLeft)
            targetVelocity = new Vector2(1,0);
        else
            targetVelocity = new Vector2(-1, 0);
    }
    
}
