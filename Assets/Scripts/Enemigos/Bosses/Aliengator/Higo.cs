using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Higo : MonoBehaviour
{
    public GameObject aliengator;
    public float elapsedTime = 0;
    public bool tocado = false;

    // Start is called before the first frame update
    void Start()
    {
        Aliengator aliengatorCodigo = aliengator.GetComponent<Aliengator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tocado)
        {
            if (elapsedTime < 7f)
                {
                    elapsedTime += Time.deltaTime;
                }
            else
            {
                tocado = false;
                gameObject.SetActive(true);
                gameObject.GetComponent<Animator>().Play("Higo");
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Aliengator aliengatorCodigo = aliengator.GetComponent<Aliengator>();

        if (collision.gameObject.name == "lengua" && aliengatorCodigo.lengua)
        {            
            //Set de valores para el aliengator
            aliengatorCodigo.golpes++;
            aliengatorCodigo.elapsedTime = 0;
            aliengatorCodigo.accion = 5;
            aliengatorCodigo.idle = false;
            aliengatorCodigo.dash = false;
            aliengatorCodigo.lengua = false;
            aliengatorCodigo.desmayo = true;
            aliengatorCodigo.gameObject.GetComponent<Animator>().SetBool("idle", false);
            aliengatorCodigo.gameObject.GetComponent<Animator>().SetBool("dash", false);
            aliengatorCodigo.gameObject.GetComponent<Animator>().SetBool("lengua", false);
            aliengatorCodigo.gameObject.GetComponent<Animator>().SetBool("desmayo", true);
            tocado = true;
            gameObject.SetActive(false);
        }
    }
}
