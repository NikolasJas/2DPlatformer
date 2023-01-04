using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclops_Dropper : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);

        Instantiate (bullet, transform.position, Quaternion.identity);

        StartCoroutine(Attack());
    }
}
