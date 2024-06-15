using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Camara : MonoBehaviour
{
    public Transform jugador;
    public float altura = 5f;
    public float velocidadCamara = 15f;
    private Vector3 velocity = Vector3.zero;
    public bool suavizado = false;
    private Vector3 nuevaPosicion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        

        if (jugador != null)
        {
            // Define la posición objetivo de la cámara
            Vector3 targetPosition = new Vector3(jugador.position.x, jugador.position.y + altura, transform.position.z);

            // Interpola suavemente la posición de la cámara hacia la posición objetivo
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, velocidadCamara);
        }

        
    }
}
