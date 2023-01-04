using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D box;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
           
            anim.Play("falling");
            yield return new WaitForSeconds(.5f);
            Destroy(gameObject);
        }
    }
    
       
}
