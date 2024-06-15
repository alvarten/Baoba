using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossFinal : MonoBehaviour
{
    public int accion, fuegos =0;
    public int golpes = 0, vecesDado =0;
    public int dano;
    public int coordenadaX, coordenadaY;
    public float velocidadDash;
    private float velocidad;
    public bool turn = false;
    public Vector3 izquierda, derecha;
    private Vector3 movimiento = new Vector3(1f, 0f, 0f);
    public float elapsedTime = 0;
    public bool cambio = false, idle = false, ataque1 = true, ataque2 = true, dado = false;
    public GameObject fuegoVerPrefab;
    public GameObject instanciaPrefabFuegoVer;
    public GameObject fuegoHorPrefab;
    public GameObject instanciaPrefabFuegoHor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        accion = Random.Range(1, 5);
        if (golpes >= 10)
        {
            accion = 5;
        }
        if (cambio)
        {
            elapsedTime = 0;
            switch (accion)
            {
                case 1:
                case 2:
                    idle = true;
                    ataque1 = false;
                    ataque2 = false;
                    dado = false;
                    gameObject.GetComponent<Animator>().SetBool("idle", true);
                    gameObject.GetComponent<Animator>().SetBool("ataque1", false);
                    gameObject.GetComponent<Animator>().SetBool("ataque2", false);
                    gameObject.GetComponent<Animator>().SetBool("dado", false);
                    break;
                case 3:
                    idle = false;
                    ataque1 = true;
                    ataque2 = false;
                    dado = false;
                    gameObject.GetComponent<Animator>().SetBool("idle", false);
                    gameObject.GetComponent<Animator>().SetBool("ataque1", true);
                    gameObject.GetComponent<Animator>().SetBool("ataque2", false);
                    gameObject.GetComponent<Animator>().SetBool("dado", false);
                    break;
                case 4:
                    idle = false;
                    ataque1 = false;
                    ataque2 = true;
                    dado = false;
                    gameObject.GetComponent<Animator>().SetBool("idle", false);
                    gameObject.GetComponent<Animator>().SetBool("ataque1", false);
                    gameObject.GetComponent<Animator>().SetBool("ataque2", true);
                    gameObject.GetComponent<Animator>().SetBool("dado", false);
                    break;
                case 5:
                    idle = false;
                    ataque1 = false;
                    ataque2 = false;
                    dado = true;
                    gameObject.GetComponent<Animator>().SetBool("idle", false);
                    gameObject.GetComponent<Animator>().SetBool("ataque1", false);
                    gameObject.GetComponent<Animator>().SetBool("ataque2", false);
                    gameObject.GetComponent<Animator>().SetBool("dado", true);
                    break;
            }
            cambio = false;
        }

        //Idle
        if (idle)
        {
            if (elapsedTime < 2f)
            {

                elapsedTime += Time.deltaTime;
            }
            else
            {
                cambio = true;
            }
        }
        //Ataque uno
        if (ataque1)
        {
            if (elapsedTime < 1.5f)
            {
                if(fuegos < 6)
                {
                    coordenadaX = Random.Range(-44, 41);
                    instanciaPrefabFuegoVer = Instantiate(fuegoVerPrefab, transform.position + new Vector3(coordenadaX, +7f, 0), Quaternion.identity);
                    fuegos++;
                }

                elapsedTime += Time.deltaTime;
            }
            else
            {
                cambio = true;
                fuegos = 0;
            }
        }
        //Ataque dos
        if (ataque2)
        {
            if (elapsedTime < 1.1f)
            {
                if (fuegos < 7)
                {
                    coordenadaY = Random.Range(1, 8);
                    coordenadaX = Random.Range(1, 3);
                    if (coordenadaX == 1)
                    {
                        coordenadaX = -44;
                    }
                    else
                    {
                        coordenadaX = -3;
                    }
                    
                    instanciaPrefabFuegoHor = Instantiate(fuegoHorPrefab, transform.position + new Vector3(coordenadaX +23f , coordenadaY -7f , 0), Quaternion.identity);
                    fuegos++;
                }

                elapsedTime += Time.deltaTime;
            }
            else
            {
                cambio = true;
                fuegos = 0;
            }
        }
        //Dado
        if (dado)
        {
            golpes = 0;
            if (elapsedTime < 3.05f)
            {

                elapsedTime += Time.deltaTime;
            }
            else
            {
                vecesDado++;
                cambio = true;
            }
            if(vecesDado >= 3)
            {
                ControladorBosses controlBoss = FindAnyObjectByType<ControladorBosses>();
                controlBoss.final = true;
                Destroy(gameObject);
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ControladorVida controlVida = FindAnyObjectByType<ControladorVida>();

        if (collision.gameObject.tag == "BolaFuegoHor")
        {
            golpes++;
        }        
        
    }
}
