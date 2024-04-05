using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioTamaño : MonoBehaviour
{
    private bool cambio = false;
    public Vector3 normal = new Vector3(1f, 1f, 1f);
    public Vector3 pequeño = new Vector3(0.5f, 0.5f, 1f);
    //private Transform transform;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform transformJugador = GetComponent<Transform>();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (cambio)
            {
                transform.localScale *= 2 ;
                cambio = false;
            }
            else if (!cambio)
            {
                transform.localScale /= 2;
                cambio = true;
            }
        }
    }
}
