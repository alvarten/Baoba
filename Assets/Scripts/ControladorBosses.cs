using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBosses : MonoBehaviour
{
    public float elapsedTime = 0;
    public GameObject panelVictoria;
    public GameObject BossFight1, BossFight2, BossFight3;
    public GameObject TriggerFight1, TriggerFight2, TriggerFight3;
    public GameObject CamaraAudio;
    public bool aliengator = false, submarino = false, final = false;
    public bool aliengatorTic = true, submarinoTic = true, finalTic = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioCamara Audio = CamaraAudio.GetComponent<AudioCamara>();
        if (aliengator && aliengatorTic)
        {
            Destroy(BossFight1);
            TriggerFight1.SetActive(false);
            Audio.track = 2;
            Audio.cambio = true;
            aliengatorTic = false;
        }
        if (submarino && submarinoTic)
        {
            Destroy(BossFight2);
            TriggerFight2.SetActive(false);
            Audio.track = 2;
            Audio.cambio = true;
            submarinoTic = false;
        }
        if (final && finalTic)
        {
            Destroy(BossFight3);
            TriggerFight3.SetActive(false);
            Audio.track = 2;
            Audio.cambio = true;
            finalTic = false;
        }

        if (aliengator && submarino && final)
        {
            if (elapsedTime < 2f)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                Time.timeScale = 0;
                panelVictoria.SetActive(true);
            }
            
        }
    }
}
