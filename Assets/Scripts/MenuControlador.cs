using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControlador : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject panelMenu;
    public bool pausaActivo = false;
    public bool menuActivo = false;
    // Start is called before the first frame update
    void Start()
    {
        panelMenu.SetActive(true);
        menuActivo = true;
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        //Detectamos si se pulsan las teclas de pausa
        if ((Input.GetKeyDown("p") || Input.GetKeyDown(KeyCode.Escape)) && pausaActivo == true)
        {
            ResumeGame();
            panelPausa.SetActive(false);
            pausaActivo = false;
        }
        else if ((Input.GetKeyDown("p") || Input.GetKeyDown(KeyCode.Escape)) && pausaActivo == false)
        {
            PauseGame();
            panelPausa.SetActive(true);
            pausaActivo = true;
        }

    }


    //Distintas funciones de los botones
    public void PausaContinuar()
    {
        ResumeGame();
        panelPausa.SetActive(false);
        pausaActivo = false;
    }
    public void PausaSalir()
    {
        panelPausa.SetActive(false);
        pausaActivo = false;
        PauseGame();
        panelMenu.SetActive(true);
        menuActivo = true;
    }
    public void PrincipalJugar()
    {
        ResumeGame();
        panelMenu.SetActive(false);
        menuActivo = false;
    }
    public void PrincipalSalir()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        Debug.Log("Pausado");
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Debug.Log("Restart");
        Time.timeScale = 1;
    }

}
