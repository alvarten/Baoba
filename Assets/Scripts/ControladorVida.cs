using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorVida : MonoBehaviour
{
    public float vida = 100;
    public float vidaAnterior;
    public bool da�ado = false;
    public float vidaMaxima = 100;
    public float inmunidadDuracion = 4;
    private bool isCoroutineRunning = false;
    public bool muerto = false;
    public GameObject panelMuerte;
    public GameObject barraVidaObjeto;
    public GameObject bossFight1, bossFight2, bossFight3;
    public Image barraVida;
    public GameObject CamaraAudio;
    // Start is called before the first frame update
    void Start()
    {
        vidaAnterior = vida;
    }

    // Update is called once per frame
    void Update()
    {
        AudioCamara Audio = CamaraAudio.GetComponent<AudioCamara>();

        if (da�ado && !isCoroutineRunning)
        {
            // Inicia la corrutina para manejar el estado de da�o
            StartCoroutine(Inmunidad());
        }

        if (vida > 0)
        {
            barraVida.transform.localScale = new Vector2(vida / vidaMaxima, 1);

        }

        if (vida < 0)
        {
            barraVida.transform.localScale = new Vector2(0, 1);

            muerto = true;

        }


        if (muerto)
        {
            Debug.Log("muerto");
            panelMuerte.SetActive(true);
            //Pauso el juego
            Time.timeScale = 0;
            barraVidaObjeto.SetActive(false);
            barraVidaObjeto.SetActive(false);
            //Desactivo todos los boses
            bossFight1.SetActive(false);
            bossFight2.SetActive(false);
            bossFight3.SetActive(false);

            
            Audio.track = 2;
            Audio.cambio = true;
        }

        vidaAnterior = vida;
    }

    IEnumerator Inmunidad()
    {
        isCoroutineRunning = true;
        // Sal del if inmediatamente si la corrutina ya est� ejecut�ndose
        if (da�ado == false) yield break;

        // Espera la duraci�n especificada
        yield return new WaitForSeconds(inmunidadDuracion);

        // Establece da�ado en false despu�s de esperar
        da�ado = false;
        isCoroutineRunning = false;
    }
}
