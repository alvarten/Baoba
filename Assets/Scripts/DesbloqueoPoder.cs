using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloqueoPoder : MonoBehaviour
{
    public GameObject Jugador;
    public int poder;
    // Start is called before the first frame update
    void Start()
    {
        CambioCuerpo jugadorCambio = Jugador.GetComponent<CambioCuerpo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CambioCuerpo playerCuerpo = FindAnyObjectByType<CambioCuerpo>();
        Movimiento playerMov = FindAnyObjectByType<Movimiento>();

        if (other.gameObject.name == "Jugador")
        {
            if(poder == 1)
            {
                playerCuerpo.BasicoDesbloqueado = true;
                Destroy(gameObject);
            }
            if (poder == 2)
            {
                playerMov.DobleSaltoDesbloqueado = true;
                Destroy(gameObject);
            }
            if (poder == 3)
            {
                playerMov.caerLentoDesbloqueado = true;
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
