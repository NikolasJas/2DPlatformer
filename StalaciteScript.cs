using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalaciteScript : MonoBehaviour
{
    private BoxCollider2D box;
    public GameObject FallingStalacite;
  //  public Rigidbody2D rb;
    public Transform FallingLocation;


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            StartCoroutine(Fall());
            yield return new WaitForSeconds(.05f);
            Destroy(gameObject);
            //GetComponent<Rigidbody2D>().isKinematic = true;
            //GetComponent<Rigidbody2D>().gravityScale = 1f;
           
        } 
    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(.03f);

        Instantiate(FallingStalacite, FallingLocation.position, Quaternion.identity);

    }

}
