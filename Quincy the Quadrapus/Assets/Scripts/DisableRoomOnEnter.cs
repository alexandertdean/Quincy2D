using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRoomOnEnter : MonoBehaviour
{
    private UnityEngine.Tilemaps.TilemapRenderer obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<UnityEngine.Tilemaps.TilemapRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        obj.enabled = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        obj.enabled = true;
    }
}
