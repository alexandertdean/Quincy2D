using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody2D obj;
    private BoxCollider2D collider;
    private BoxCollider2D trigger;
    // Start is called before the first frame update
    void Start()
    {
        obj = this.transform.parent.gameObject.GetComponent<Rigidbody2D>();
        collider = this.transform.parent.gameObject.GetComponent<BoxCollider2D>();
        trigger = GetComponent<BoxCollider2D>();
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player") {
            Rigidbody2D playerBody = other.gameObject.GetComponent<Rigidbody2D>();
            switch(this.tag) {
                case "MovingPlatform":
                    break;
                case "Enemy":
                    if (other.bounds.center.y >= trigger.bounds.center.y - trigger.bounds.extents.y) {
                        if (other.gameObject.GetComponent<PlayerPlatformerController>().setHitEnemy(true)) {
                            Destroy(this.gameObject);
                            Destroy(this.transform.parent.gameObject);
                        }
                    }
                    break;
                case "Bucket":
                    if (other.bounds.center.y - other.bounds.extents.y >= trigger.bounds.center.y - .2) {
                        if (other.gameObject.GetComponent<PlayerPlatformerController>().setInBucket(true, trigger)) {
                            this.transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        }
                    }
                    break;
                default:
                    Debug.Log("Invalid tag assigned to collider player is interacting with");
                    break;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player") {
            Rigidbody2D playerBody = other.gameObject.GetComponent<Rigidbody2D>();
            switch(this.tag) {
                case "MovingPlatform":
                    if (playerBody.IsTouching(collider)) {
                        playerBody.velocity = obj.velocity;
                    }
                    break;
                case "Enemy":
                    break;
                case "Bucket":
                    break;
                default:
                    Debug.Log("Invalid tag assigned to collider player is interacting with");
                    break;
            }
        }
        else if (this.tag == "Enemy") 
        {
            Rigidbody2D body = other.gameObject.GetComponent<Rigidbody2D>();
            switch(this.tag) {
                case "MovingPlatform":
                    if (body.IsTouching(collider)) {
                        body.velocity = obj.velocity;
                    }
                    break;
                case "Enemy":
                    break;
                case "Bucket":
                    break;
                default:
                    Debug.Log("Invalid tag assigned to collider player is interacting with");
                    break;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") {
            Rigidbody2D playerBody = other.gameObject.GetComponent<Rigidbody2D>();
            switch(this.tag) {
                case "MovingPlatform":
                    playerBody.velocity = new Vector2(0,0);
                    break;
                case "Enemy":
                    playerBody.velocity = new Vector2(0,0);
                    break;
                case "Bucket":
                    break;
                default:
                    Debug.Log("Invalid tag assigned to collider player is interacting with");
                    break;
            }
        }
    }

}
