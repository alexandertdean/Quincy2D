using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPearl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        // do level win logic here
    }
}
