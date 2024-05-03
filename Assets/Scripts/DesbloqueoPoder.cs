using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloqueoPoder : MonoBehaviour
{
    public GameObject Jugador;
    // Start is called before the first frame update
    void Start()
    {
        CambioCuerpo controladorCheckpoint = Jugador.GetComponent<CambioCuerpo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CambioCuerpo player = FindAnyObjectByType<CambioCuerpo>();


        if (other.gameObject.name == "Jugador")
        {

            player.BasicoDesbloqueado = true;
        }
    }
}
