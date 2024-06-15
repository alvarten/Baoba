using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burbuja : MonoBehaviour
{    
    public bool tocado = false;
    public float elapsedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.name == "submarino")
        {            
            Destroy(gameObject);
        }
        if (collision.transform.tag == "ground")
        {            
            Destroy(gameObject);
        }        
        Destroy(gameObject);
    }
}
