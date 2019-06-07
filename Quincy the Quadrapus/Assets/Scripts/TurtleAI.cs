using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleAI : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private Vector3 startPos;
    public Vector3 travelTo;
    private Vector3 direction;
    private bool toStartPos;
    private Animator animator;
    private SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        startPos = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        toStartPos = false;
        direction = travelTo - startPos;
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, startPos) <= .1f && toStartPos)
        {
            direction = direction * -1;
            toStartPos = false;
            render.flipX = !render.flipX;
        }
        else if (Vector3.Distance(transform.position, travelTo) <= .1f && !toStartPos)
        {
            direction = direction * -1;
            toStartPos = true;
            render.flipX = !render.flipX;
        }
        rigidbody.velocity = direction.normalized * 2;
    }
}
