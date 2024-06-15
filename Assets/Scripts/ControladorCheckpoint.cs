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
            case "Checkpoint1.1":

                pantalla = 1;
                Debug.Log("Zona1");
                break;
            case "Checkpoint1.2":

                pantalla = 2;
                Debug.Log("Zona2");
                break;
            case "Checkpoint1.3":

                pantalla = 3;
                
                break;
            case "Checkpoint1.4":

                pantalla = 4;
                
                break;
            case "Checkpoint1.5":

                pantalla = 5;

                break;
            case "Checkpoint1.6":

                pantalla = 6;

                break;
            case "Checkpoint1.7":

                pantalla = 7;

                break;
            case "Checkpoint1.8":

                pantalla = 8;

                break;

        }
    }


}
