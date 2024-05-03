using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject panelMuerte;
    public GameObject barraVidaObjeto;
    public GameObject personaje;
    public GameObject ControladorCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        ControladorCheckpoint controladorCheckpoint = ControladorCheckpoint.GetComponent<ControladorCheckpoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ReseteoDePosiciones ()
    {
        ControladorCheckpoint controladorCheckpoint = FindAnyObjectByType<ControladorCheckpoint>();
        float zona = controladorCheckpoint.pantalla;
        Transform transformDelPersonaje = personaje.transform;

        //Cambiamos al personaje de sitio dependiendo de su progreso
        if (controladorCheckpoint.pantalla == 1)
        {
            transformDelPersonaje.position = new Vector3(-7.1f, -1.1f, 0);
        }
        if (controladorCheckpoint.pantalla == 2)
        {
            transformDelPersonaje.position = new Vector3(158.4f, 66f, 0);
        }
        if (controladorCheckpoint.pantalla == 3)
        {
            transformDelPersonaje.position = new Vector3(286.6f, 106.7f, 0);
        }
        if (controladorCheckpoint.pantalla == 4)
        {
            transformDelPersonaje.position = new Vector3(373.4f, 199.7f, 0);
        }

        //Volvemos a mostrar la pantalla normal
        barraVidaObjeto.SetActive(true);
        panelMuerte.SetActive(false);
        //Volvemos a ponerle con toda la vida
        ControladorVida controlVida = FindAnyObjectByType<ControladorVida>();
        controlVida.muerto = false;
        controlVida.vida = 100;


    }

}
