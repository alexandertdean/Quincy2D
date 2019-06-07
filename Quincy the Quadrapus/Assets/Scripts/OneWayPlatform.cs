using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{

    private BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = this.transform.parent.gameObject.GetComponent<BoxCollider2D>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.bounds.center.y - other.bounds.extents.y < collider.bounds.center.y + collider.bounds.extents.y) {
            collider.enabled = false;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
            collider.enabled = true;
    }
}
