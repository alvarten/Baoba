using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CambioCuerpo : MonoBehaviour
{
    //Forma actual
    public bool formaTronco = true;
    public bool formaBasico = false;
    public bool BasicoDesbloqueado = false;



    private bool contactoTronco = false;
    public Sprite tronco;
    public Sprite basico;

    //Prefabs de los personajes
    public GameObject troncoPrefab;
    public GameObject instanciaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //El renderizador de sprites
        SpriteRenderer spriteRend = GetComponent<SpriteRenderer>();
        BoxCollider2D collider2d = GetComponent<BoxCollider2D>();
        Transform transformJugador = GetComponent<Transform>();

        if (Input.GetKeyDown(KeyCode.Q))
        {

            //Cambio de cuerpo
            //Esta en forma basica
            if (formaBasico && contactoTronco)
            {

                spriteRend.sprite = tronco;
                collider2d.size = new Vector2(1.67f, 2.86f);
                collider2d.offset = new Vector2(-0.15f, -0.55f);
                Debug.Log("destruir");
                Destroy(instanciaPrefab, .1f);
                formaTronco = true;
                formaBasico = false;
                gameObject.GetComponent<Animator>().SetBool("tronco", true);
                gameObject.GetComponent<Animator>().SetBool("baoba", false);

            }
            //Está en forma grande
            else if (!formaBasico && BasicoDesbloqueado)
            {
                if (formaTronco)
                {
                    instanciaPrefab = Instantiate(troncoPrefab, transform.position + new Vector3(0, 0f, 0), Quaternion.identity);
                    gameObject.GetComponent<Animator>().SetBool("tronco", false);
                    gameObject.GetComponent<Animator>().SetBool("baoba", true);
                }
                
                //Configuración de forma basica
                spriteRend.sprite = basico;
                collider2d.size = new Vector2(1.3f, 2f);
                collider2d.offset = new Vector2(0.07f, -1.18f);
                formaBasico = true;
                formaTronco = false;
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

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Verificar si el otro Collider es de un tipo específico y si es un trigger
        if (other.CompareTag("tronco") && other.isTrigger)
        {
            contactoTronco = false;
            Debug.Log("Fuera Tronco");
        }

    }
}
