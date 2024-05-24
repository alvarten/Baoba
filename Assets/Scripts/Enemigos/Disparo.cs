using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public int dano;
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
        ControladorVida controlVida = FindAnyObjectByType<ControladorVida>();        

        if (collision.gameObject.name == "Jugador" && controlVida.dañado == false)
        {
            controlVida.vida -= dano;
            controlVida.dañado = true;
            Destroy(gameObject);
        }
        if (collision.transform.tag == "ground")
        {
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
