 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

public class Movimiento : MonoBehaviour
{

    //Version Beta

    //booleanos para el salto
    public bool canJump, dobleSalto, caerLento, DobleSaltoDesbloqueado = false;
    public int salto = 0;
    public float velocidadMovVertical = 20f;
    public float velocidad = 65f;
    private bool isCoroutineRunning = false;
    public bool canDash = true;
    public float dashCool = 10f;
    [SerializeField] public float velocidadMovimientoH = 65f;
    [SerializeField] public float velocidadMovimientoHCaida = 40f;
    public float velocidadMovHorizontal= 65f;
    public float fuerzaDash = 15f;
    [SerializeField] private float fuerzaSalto = 20f;
    [SerializeField] private float planeo = 1.0f;
    public CambioCuerpo cambioCuerpo;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Las distintas propiedades de movimiento de los distintos personajes

        if (cambioCuerpo.formaTronco)
        {
            velocidadMovimientoH = 100f;
            velocidadMovHorizontal = 100f;
            fuerzaSalto = 45f;
        }
        else if (cambioCuerpo.formaBasico)
        {

            velocidadMovimientoH = 85f;
            velocidadMovHorizontal = 85f;
            fuerzaSalto = 33f;
        }
        else if (cambioCuerpo.formaVoladora)
        {
            
            velocidadMovimientoH = 75f;
            velocidadMovHorizontal = 75f;
            fuerzaSalto = 27f;
        }
        else if (cambioCuerpo.formaAgua)
        {
            velocidadMovimientoH = 100f;
            velocidadMovHorizontal = 100f;            
        }



        //Movimiento horizontal
        //Izquierda
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-velocidadMovHorizontal * Time.deltaTime, 0));            
            gameObject.GetComponent<Animator>().SetBool("moving", true);

            Vector3 escala = transform.localScale;
            escala.x = -escala.y;
            transform.localScale = escala;

        }
        //Derecha
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(velocidadMovHorizontal * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);

            Vector3 escala = transform.localScale;
            escala.x = escala.y;
            transform.localScale = escala;


        }
        //Idle
        if (!Input.GetKey("right") && !Input.GetKey("d") && !Input.GetKey("left") && !Input.GetKey("a"))
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }


        //Salto, doble salto
        if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && !cambioCuerpo.formaAgua)
        {


            //Baoba Doble salto
            if (salto == 1 && dobleSalto && cambioCuerpo.formaBasico && DobleSaltoDesbloqueado)
            {
                dobleSalto = false;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto * 1.2f));
                salto += 1;
            }
            //Baoba planeo
            if ((Input.GetKey("up") || Input.GetKey("w")) && salto == 2 && cambioCuerpo.formaBasico && DobleSaltoDesbloqueado)
            {
                caerLento = true;
            }
            //Voladora
            if ((Input.GetKey("up") || Input.GetKey("w")) && salto == 1 && cambioCuerpo.formaVoladora)
            {
                gameObject.GetComponent<Animator>().SetBool("volar", true);
                dobleSalto = false;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto * 2.6f));
                salto += 1;
            }
            if (salto == 0 && canJump)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));
                salto += 1;               
            }

            
        }

        //Planeo

        //volador
        //Pulsado
        if ((Input.GetKey("up") || Input.GetKey("w")) && salto == 2 && cambioCuerpo.formaVoladora)
        {
            gameObject.GetComponent<Animator>().SetBool("volar", true);
            gameObject.GetComponent<Rigidbody2D>().gravityScale = planeo;
            velocidadMovHorizontal = velocidadMovimientoHCaida;
        }
        //Sin Pulsar
        if ((Input.GetKeyUp("up") || Input.GetKeyUp("w")) && salto == 2 && cambioCuerpo.formaVoladora)
        {
            gameObject.GetComponent<Animator>().SetBool("volar", false);
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 2.3f;
            velocidadMovHorizontal = velocidadMovimientoH;
        }
        //Baoba
        //Pulsado
        if ((Input.GetKey("up") || Input.GetKey("w")) && salto == 2 && cambioCuerpo.formaBasico && DobleSaltoDesbloqueado)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = planeo;
            velocidadMovHorizontal = velocidadMovimientoHCaida;
        }
        //Sin Pulsar
        if ((Input.GetKeyUp("up") || Input.GetKeyUp("w")) && salto == 2 && cambioCuerpo.formaBasico && DobleSaltoDesbloqueado)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 2.3f;
            velocidadMovHorizontal = velocidadMovimientoH;
        }



        //Movimiento forma agua
        if (cambioCuerpo.formaAgua)
        {
            //Cambiamos la escala de gravedad para que flote
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.001f;
            //movimiento vertical
            if ((Input.GetKey("up") || Input.GetKey("w")))
            {
                velocidad = velocidadMovVertical;
                transform.position += (new Vector3(0, 1f * velocidad, 0) * Time.deltaTime);
            }
            else if ((Input.GetKey("down") || Input.GetKey("s")))
            {
                velocidad = -velocidadMovVertical;
                transform.position += (new Vector3(0, 1f * velocidad, 0) * Time.deltaTime);
            }

            //Dash
            if (Input.GetKey(KeyCode.LeftShift) && canDash)
            {
                //Gestionamos el dash con una funcion
                HacerDash();                             
                
            }


        }
        

    }

    //Reseteo de vuelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            //Volvemos a poner la escala de gravedad en su valor normal
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 2.3f;
        }
    }



    //Funcion de Dash 
    void HacerDash()
    {
        Vector3 escala = transform.localScale;
        gameObject.GetComponent<Animator>().SetBool("dash", true);
        //aplicamos la fuerza a baoba
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaDash * escala.x, 0f));

        //llamamos a la espera
        StartCoroutine(DashCooldown());
    }
    IEnumerator DashCooldown()
    {
        canDash = false;        

        // Espera el tiempo especificado
        yield return new WaitForSeconds(dashCool);

        // Permite que la acción se pueda realizar nuevamente
        canDash = true;
        gameObject.GetComponent<Animator>().SetBool("dash", false);

        
    }

}
