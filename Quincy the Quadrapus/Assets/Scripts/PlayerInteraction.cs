using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody2D obj;
    private BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        obj = this.transform.parent.gameObject.GetComponent<Rigidbody2D>();
        collider = this.transform.parent.gameObject.GetComponent<BoxCollider2D>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player") {
            switch(this.tag) {
                case "MovingPlatform":
                    Rigidbody2D playerBody = other.gameObject.GetComponent<Rigidbody2D>();
                    if (playerBody.IsTouching(collider)) {
                        playerBody.velocity = obj.velocity;
                    }
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
            switch(this.tag) {
                case "MovingPlatform":
                    other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                    break;
                default:
                    Debug.Log("Invalid tag assigned to collider player is interacting with");
                    break;
            }
        }
    }

}
