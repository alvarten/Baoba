 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Movimiento : MonoBehaviour
{

    //Version Alpha

    //booleanos para el salto
    public bool canJump, dobleSalto, caerLento;
    public int salto = 0;

    [SerializeField] public float velocidadMovimientoH = 65f;
    [SerializeField] public float velocidadMovimientoHCaida = 40f;
    public float velocidadMovHorizontal= 65f;
    [SerializeField] private float fuerzaSalto = 20f;
    [SerializeField] private float planeo = 5f;
    public CambioCuerpo cambioCuerpo;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //En caso de ser forma tronco tiene más velocidad de movimiento y salto

        if (cambioCuerpo.formaTronco)
        {
            velocidadMovimientoH = 80f;
            velocidadMovHorizontal = 80f;
            fuerzaSalto = 35f;
        }
        else if (cambioCuerpo.formaBasico)
        {
            Debug.Log("basico");
            velocidadMovimientoH = 65f;
            velocidadMovHorizontal = 65f;
            fuerzaSalto = 20f;
        }


        //Movimiento horizontal
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-velocidadMovHorizontal * Time.deltaTime, 0));            
            gameObject.GetComponent<Animator>().SetBool("moving", true);

            Vector3 escala = transform.localScale;
            escala.x = -escala.y;
            transform.localScale = escala;

        }

        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(velocidadMovHorizontal * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);

            Vector3 escala = transform.localScale;
            escala.x = escala.y;
            transform.localScale = escala;


        }
        if (!Input.GetKey("right") && !Input.GetKey("d") && !Input.GetKey("left") && !Input.GetKey("a"))
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }


        //Salto y doble salto
        if ((Input.GetKeyDown("up") || Input.GetKeyDown("w"))){


            
            if (salto == 1 && dobleSalto && cambioCuerpo.formaBasico)
            {
                dobleSalto = false;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto * 1.4f));
                salto += 1;
            }
            if ((Input.GetKey("up") || Input.GetKey("w")) && salto == 2 && cambioCuerpo.formaBasico)
            {
                caerLento = true;
            }
            if (salto == 0 && canJump)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));
                salto += 1;                
            }

            
        }

        //Planeo
        if ((Input.GetKey("up") || Input.GetKey("w")) && salto == 2)
        {            
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
            velocidadMovHorizontal = velocidadMovimientoHCaida;
        }
        
        if ((Input.GetKeyUp("up") || Input.GetKeyUp("w")) && salto == 2)
        {            
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
            velocidadMovHorizontal = velocidadMovimientoH;
        }
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {            
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
    }
    
}
