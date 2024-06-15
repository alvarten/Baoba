using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarBoss : MonoBehaviour
{
    public GameObject bossFight;
    public GameObject CamaraAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        

        if (collision.gameObject.name == "Jugador")
        {
            AudioCamara Audio = CamaraAudio.GetComponent<AudioCamara>();
            Audio.track = 3;
            Audio.cambio = true;
            bossFight.SetActive(true);
        }
        
    }
}
