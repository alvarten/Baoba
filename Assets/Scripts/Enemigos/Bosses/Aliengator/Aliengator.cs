using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliengator : MonoBehaviour
{
    public int accion;
    public int golpes =0;
    public int dano;
    public float velocidadDash;
    private float velocidad;
    public bool turn = false;
    public Vector3 izquierda, derecha;
    private Vector3 movimiento = new Vector3(1f, 0f, 0f);
    public float elapsedTime = 0;
    public bool cambio = false, idle = false, dash = true, lengua = true, desmayo = false;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = velocidadDash;
    }

    // Update is called once per frame
    void Update()
    {

        accion = Random.Range(1, 5);

        //Si se tiene que cambiar de acción se elije una al azar
        if (cambio)
        {
            elapsedTime = 0;
            switch (accion)
            {
                case 1:
                case 2:
                    idle = true;
                    dash = false;
                    lengua = false;
                    desmayo = false;
                    gameObject.GetComponent<Animator>().SetBool("idle", true);
                    gameObject.GetComponent<Animator>().SetBool("dash", false);
                    gameObject.GetComponent<Animator>().SetBool("lengua", false);
                    gameObject.GetComponent<Animator>().SetBool("desmayo", false);
                    break;
                case 3:
                    idle = false;
                    dash = true;
                    lengua = false;
                    desmayo = false;
                    gameObject.GetComponent<Animator>().SetBool("idle", false);
                    gameObject.GetComponent<Animator>().SetBool("dash", true);
                    gameObject.GetComponent<Animator>().SetBool("lengua", false);
                    gameObject.GetComponent<Animator>().SetBool("desmayo", false);
                    break;
                case 4:
                    idle = false;
                    dash = false;
                    lengua = true;
                    desmayo = false;
                    gameObject.GetComponent<Animator>().SetBool("idle", false);
                    gameObject.GetComponent<Animator>().SetBool("dash", false);
                    gameObject.GetComponent<Animator>().SetBool("lengua", true);
                    gameObject.GetComponent<Animator>().SetBool("desmayo", false);
                    break;
                case 5:
                    idle = false;
                    dash = false;
                    lengua = false;
                    desmayo = true;
                    gameObject.GetComponent<Animator>().SetBool("idle", false);
                    gameObject.GetComponent<Animator>().SetBool("dash", false);
                    gameObject.GetComponent<Animator>().SetBool("lengua", false);
                    gameObject.GetComponent<Animator>().SetBool("desmayo", true);
                    break;
            }
            cambio = false;
        }
        

        //Acciones

        //Se mantiene estatico 
        if (idle)
        {
            if (elapsedTime < 3)
            {

                elapsedTime += Time.deltaTime;
            }
            else
            {
                cambio = true;
            }
        }

        //Hace un dash hacia delante
        if (dash)
        {
            if(elapsedTime < 10)
            {
                if (transform.position.x > derecha.x)
                    {
                        velocidad = -velocidadDash;
                        if (turn)
                        {
                        Vector3 escala = transform.localScale;
                        escala.x = escala.y;
                        transform.localScale = escala;
                    }
                }
                else if (transform.position.x < izquierda.x)
                {
                    velocidad = velocidadDash;
                    if (turn)
                    {
                    Vector3 escala = transform.localScale;
                    escala.x = -escala.y;
                    transform.localScale = escala;
                    }
                }
                elapsedTime += Time.deltaTime;
                transform.position += movimiento * velocidad * Time.deltaTime;
            }else
            {
                cambio = true;
            }
        }

        //Ataque de lengua
        if (lengua)
        {
            if (elapsedTime < 1.02f)
            {

                elapsedTime += Time.deltaTime;
            }
            else
            {
                cambio = true;
            }
        }
        //Dañado
        if (desmayo)
        {
            if (elapsedTime < 2.2f)
            {

                elapsedTime += Time.deltaTime;
            }
            else if (golpes >= 3)
            {
                ControladorBosses controlBoss = FindAnyObjectByType<ControladorBosses>();
                controlBoss.aliengator = true;
                Destroy(gameObject);
            }
            else
            {
                cambio = true;
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ControladorVida controlVida = FindAnyObjectByType<ControladorVida>();
        if (collision.gameObject.name == "Jugador" && controlVida.dañado == false)
        {
            controlVida.vida -= dano;
            controlVida.dañado = true;
        }
    }
}
