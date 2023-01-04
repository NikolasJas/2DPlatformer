using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       if (Door.instance != null)
        {
            Door.instance.collectablesCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            Destroy(gameObject);
            if(Door.instance != null)
            {
                Door.instance.DecrementCollectables();
            }
        }
    }

}
