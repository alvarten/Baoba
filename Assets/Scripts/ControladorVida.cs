using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorVida : MonoBehaviour
{
    public float vida = 100;
    public float vidaMaxima = 100;
    public bool muerto = false;
    public GameObject panelMuerte;
    public GameObject barraVidaObjeto;
    public Image barraVida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida > 0)
        {
            barraVida.transform.localScale = new Vector2(vida / vidaMaxima, 1);

        }

        if (vida < 0)
        {
            barraVida.transform.localScale = new Vector2(0, 1);

            muerto = true;

        }


        if (muerto)
        {
            Debug.Log("muerto");
            panelMuerte.SetActive(true);
            barraVidaObjeto.SetActive(false);
        }


    }
}
