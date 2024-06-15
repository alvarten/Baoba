using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LenguaAliengator : MonoBehaviour
{
    public GameObject aliengator;
    // Start is called before the first frame update
    void Start()
    {
        Aliengator aliengatorCodigo = aliengator.GetComponent<Aliengator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Aliengator aliengatorCodigo = aliengator.GetComponent<Aliengator>();
        
        if (collision.gameObject.tag == "higo" && aliengatorCodigo.lengua)
        {
            Debug.Log("higo");
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
            Debug.Log("higo2");
        }
    }
}
