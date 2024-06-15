using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCamara : MonoBehaviour
{
    public AudioClip ambiente, boos, menu; // Clips de audio para elegir
    private AudioSource audioSource;
    public bool cambio = true;
    public int track; //
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (cambio)
        {
            switch (track)
            {
                case 1:
                    audioSource.clip = menu;
                    audioSource.Play();
                    cambio = false;
                    break;
                case 2:
                    audioSource.clip = ambiente;
                    audioSource.Play();
                    cambio = false;
                    break;
                case 3:
                    audioSource.clip = boos;
                    audioSource.Play();
                    cambio = false;
                    break;
            }
        }
        



    }
}
