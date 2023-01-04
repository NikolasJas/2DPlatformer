using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lvl1()
    {
        SceneManager.LoadScene("Lvl.1");
    }

    public void Lvl2()
    {
    SceneManager.LoadScene("Lvl.2");
    }

    public void Lvl3()
    {
    SceneManager.LoadScene("Lvl.3");
    } 

  
}
