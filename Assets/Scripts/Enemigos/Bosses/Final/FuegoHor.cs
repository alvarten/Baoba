using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoHor : MonoBehaviour
{
    public float velocidadMovHorizontal;
    private float velocidad;
    public bool turn = false;
    public Vector3 izquierda, derecha;
    private Vector3 movimiento = new Vector3(1f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        velocidad = velocidadMovHorizontal;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > derecha.x)
        {
            velocidad = -velocidadMovHorizontal;
            if (turn)
            {
                Vector3 escala = transform.localScale;

                escala.x = escala.y;
                transform.localScale = escala;
            }
        }
        else if (transform.position.x < izquierda.x)
        {
            velocidad = velocidadMovHorizontal;
            if (turn)
            {
                Vector3 escala = transform.localScale;
                escala.x = -escala.y;
                transform.localScale = escala;
            }
        }

        transform.position += movimiento * velocidad * Time.deltaTime;

    }
    
}
