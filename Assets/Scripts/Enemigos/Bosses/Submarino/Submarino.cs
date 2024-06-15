using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarino : MonoBehaviour
{
    public int golpes = 0;
    public bool dado = false;
    public float elapsedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dado)
        {
            if (elapsedTime < 1.5f)
            {
                elapsedTime += Time.deltaTime;
            }
            if (golpes >= 4)
            {
                ControladorBosses controlBoss = FindAnyObjectByType<ControladorBosses>();
                controlBoss.submarino = true;
                Destroy(gameObject);
            }
            if (elapsedTime >= 1.5f)
            {
                gameObject.GetComponent<Animator>().SetBool("dado", false);
                dado = false;                
                elapsedTime = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "burbuja")
        {
            golpes++;
            dado = true;            
            gameObject.GetComponent<Animator>().SetBool("dado", true);

        }
    }
    }
