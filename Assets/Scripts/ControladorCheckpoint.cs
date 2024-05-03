using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCheckpoint : MonoBehaviour
{
    public float pantalla ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Detector de zona en la que estamos
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Obtener el nombre
        string nombreZona = other.gameObject.name;

        // Realizar acciones diferentes dependiendo del nombre de la zona
        switch (nombreZona)
        {
            case "Zona1.1":

                pantalla = 1;
                Debug.Log("Zona1");
                break;
            case "Zona1.2":

                pantalla = 2;
                Debug.Log("Zona2");
                break;
            case "Zona1.3":

                pantalla = 3;
                
                break;
            case "Zona1.4":

                pantalla = 4;
                
                break;
            
        }
    }


}
