using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Door2.instance != null)
        {
            Door2.instance.collectablesCount++;
        }
    }

    
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(gameObject);
            if (Door2.instance != null)
            {
                Door2.instance.DecrementCollectables();
            }
        }
    }
    //
}
