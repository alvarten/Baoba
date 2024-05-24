using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject Jugador;
    // Start is called before the first frame update
    void Start()
    {
        Movimiento controladorCheckpoint = Jugador.GetComponent<Movimiento>();
        Animator animador = Jugador.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Reset de los parametros de saltos etc
    private void OnTriggerStay2D(Collider2D other)
    {
        Movimiento player = Jugador.GetComponent<Movimiento>();
        Animator animador = Jugador.GetComponent<Animator>();

        if (other.transform.tag == "ground")
        {
            //Debug.Log("resetea valores");
            player.salto = 0;
            player.canJump = true;
            player.dobleSalto = true;
            player.caerLento = false;
            animador.SetBool("volar",false);
            player.velocidadMovHorizontal = player.velocidadMovimientoH;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Movimiento player = FindAnyObjectByType<Movimiento>();        

        if (other.transform.tag == "ground")
        {            
            player.salto = 1;
            player.canJump = false;
            player.dobleSalto = true;
            player.caerLento = false;
            
            player.velocidadMovHorizontal = player.velocidadMovimientoH;
        }
    }
}
