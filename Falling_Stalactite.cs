using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Stalactite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "ground" || target.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
