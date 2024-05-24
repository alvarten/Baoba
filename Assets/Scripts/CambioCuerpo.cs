using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CambioCuerpo : MonoBehaviour
{
    //Forma actual
    public bool formaTronco = true;
    public bool formaVoladora = false;
    public bool formaAgua = false;
    public bool formaBasico = false;
    public bool BasicoDesbloqueado = false;


    private bool contactoVoladora = false;
    private bool contactoAgua = false;
    private bool contactoTronco = false;
    public Sprite tronco;
    public Sprite basico;

    //Prefabs de los personajes
    public GameObject troncoPrefab;
    public GameObject voladoraPrefab;
    public GameObject aguaPrefab;
    public GameObject instanciaPrefabTronco;
    public GameObject instanciaPrefabVoladora;
    public GameObject instanciaPrefabAgua;
    public GameObject groundCheckObjeto;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D groundCheck = groundCheckObjeto.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //El renderizador de sprites
        SpriteRenderer spriteRend = GetComponent<SpriteRenderer>();
        BoxCollider2D collider2d = GetComponent<BoxCollider2D>();
        BoxCollider2D groundCheck = groundCheckObjeto.GetComponent<BoxCollider2D>();
        Transform transformJugador = GetComponent<Transform>();

        if (Input.GetKeyDown(KeyCode.Q))
        {

            //Cambio de cuerpo
            //De forma baoba pasa a tronco
            if (formaBasico && contactoTronco)
            {

                spriteRend.sprite = tronco;
                collider2d.size = new Vector2(1.67f, 2.86f);
                collider2d.offset = new Vector2(-0.15f, -0.55f);
                groundCheck.size = new Vector2(1.3f, 0.33f);
                groundCheck.offset = new Vector2(-0.07f, -1.57f);

                
                Destroy(instanciaPrefabTronco, .1f);
                formaTronco = true;
                formaBasico = false;
                gameObject.GetComponent<Animator>().SetBool("tronco", true);
                gameObject.GetComponent<Animator>().SetBool("baoba", false);

            }
            //De forma baoba pasa a voladora
            else if (formaBasico && contactoVoladora)
            {

                collider2d.size = new Vector2(1.57f, 2.74f);
                collider2d.offset = new Vector2(-0.1f, -0.82f);
                groundCheck.size = new Vector2(1.3f, 0.76f);
                groundCheck.offset = new Vector2(-0.07f, -1.78f);

                Debug.Log("volador");
                Destroy(instanciaPrefabVoladora, .1f);
                formaVoladora = true;
                formaBasico = false;
                gameObject.GetComponent<Animator>().SetBool("voladora", true);
                gameObject.GetComponent<Animator>().SetBool("baoba", false);

            }
            else if (formaBasico && contactoAgua)
            {

                collider2d.size = new Vector2(2.68f, 1.54f);
                collider2d.offset = new Vector2(-0.31f, -0.28f);
                groundCheck.size = new Vector2(1.3f, 0.76f);
                groundCheck.offset = new Vector2(-0.07f, -1.78f);

                Debug.Log("agua");
                Destroy(instanciaPrefabAgua, .1f);
                formaAgua = true;
                formaBasico = false;
                gameObject.GetComponent<Animator>().SetBool("agua", true);
                gameObject.GetComponent<Animator>().SetBool("baoba", false);

            }
            //De forma tronco, voladora o agua pasa a baoba
            else if (!formaBasico && BasicoDesbloqueado)
            {
                if (formaTronco)
                {
                    instanciaPrefabTronco = Instantiate(troncoPrefab, transform.position + new Vector3(0, 0f, 0), Quaternion.identity);
                    gameObject.GetComponent<Animator>().SetBool("tronco", false);
                    gameObject.GetComponent<Animator>().SetBool("baoba", true);
                }
                else if (formaVoladora)
                {
                    instanciaPrefabVoladora = Instantiate(voladoraPrefab, transform.position + new Vector3(0, 0f, 0), Quaternion.identity);
                    gameObject.GetComponent<Animator>().SetBool("voladora", false);
                    gameObject.GetComponent<Animator>().SetBool("baoba", true);
                }
                else if (formaAgua)
                {
                    instanciaPrefabAgua = Instantiate(aguaPrefab, transform.position + new Vector3(0, 0f, 0), Quaternion.identity);
                    gameObject.GetComponent<Animator>().SetBool("agua", false);
                    gameObject.GetComponent<Animator>().SetBool("baoba", true);
                }

                //Configuración de forma basica
                spriteRend.sprite = basico;
                collider2d.size = new Vector2(1.08f, 2f);
                collider2d.offset = new Vector2(0.07f, -1.18f);
                groundCheck.size = new Vector2(0.67f, 0.5f);
                groundCheck.offset = new Vector2(0.14f, -1.85f);
                formaBasico = true;
                formaTronco = false;
                formaVoladora = false;
                formaAgua = false;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el otro Collider es de un tipo específico y si es un trigger
        if (other.CompareTag("tronco") && other.isTrigger)
        {
            contactoTronco = true;
            Debug.Log("Dentro Tronco");
        }
        else if (other.CompareTag("voladora") && other.isTrigger)
        {
            contactoVoladora = true;
            Debug.Log("Dentro Voladora");
        }
        else if (other.CompareTag("agua") && other.isTrigger)
        {
            contactoAgua = true;
            Debug.Log("Dentro agua");
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Verificar si el otro Collider es de un tipo específico y si es un trigger
        if (other.CompareTag("tronco") && other.isTrigger)
        {
            contactoTronco = false;
            Debug.Log("Fuera Tronco");
        }
        else if (other.CompareTag("voladora") && other.isTrigger)
        {
            contactoVoladora = false;
            Debug.Log("Fuera Voladora");
        }
        else if (other.CompareTag("agua") && other.isTrigger)
        {
            contactoAgua = false;
            Debug.Log("Fuera agua");
        }

    }
}
