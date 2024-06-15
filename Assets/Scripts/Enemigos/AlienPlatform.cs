using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AlienPlatform : MonoBehaviour
{
    public bool restart = false, hit = false;
    public float elapsedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            elapsedTime = 0;
            hit = false;
            gameObject.GetComponent<Animator>().SetBool("hit", false);
            restart = false;
        }

        if (hit)
        {
            gameObject.GetComponent<Animator>().SetBool("hit", true);
            if (elapsedTime < 4.5f)
            {

                elapsedTime += Time.deltaTime;
            }
            else
            {
                restart = true;
            }
        }
    }

    //Detección del punto devil
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Jugador")
        {
            hit = true;
        }
    }
}
