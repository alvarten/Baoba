 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movimiento : MonoBehaviour
{ 
    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadMovimiento = 0f;
    [SerializeField] private float suavizadoMovimiento = 0f;

    private Vector3 velocidad = Vector3.zero;

    private bool mirandoDerecha = true;



    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;

        Mover(movimientoHorizontal * Time.deltaTime);

    }

    private void Mover(float mover)
    {
        Vector3 velocidadObjetivo = new Vector3(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoMovimiento);

        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
            //girar
        }
        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
            //girar
        }


    }


    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
    


}
