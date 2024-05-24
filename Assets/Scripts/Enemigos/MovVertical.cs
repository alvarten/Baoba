using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovVertical : MonoBehaviour
{
    public float velocidadMovVertical;
    public float velocidad;
    public Vector3 arriba, abajo;
    private Vector3 movimiento = new Vector3(0f, 1f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        velocidad = velocidadMovVertical;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > arriba.y)
        {
            velocidad = -velocidadMovVertical;
        }
        else if (transform.position.y < abajo.y)
        {
            velocidad = velocidadMovVertical;
        }

        transform.position += movimiento * velocidad * Time.deltaTime;
    }
}
