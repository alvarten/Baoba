using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform jugador;
    public float altura = 5f;
    public float velocidadCamara = 15f;
    public bool suavizado = false;
    private Vector3 nuevaPosicion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nuevaPosicion = this.transform.position;
        nuevaPosicion.x = jugador.transform.position.x ;
        nuevaPosicion.y = jugador.transform.position.y + altura;

        if (suavizado)
        {
            this.transform.position =
                Vector3.Lerp(this.transform.position, nuevaPosicion, velocidadCamara * Time.deltaTime);
        }
        else
        {
            this.transform.position = nuevaPosicion;
        }

    }
}
