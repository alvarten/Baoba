using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Concha : MonoBehaviour
{
    public float elapsedTime = 0;
    public bool cooldown = true;
    public GameObject burbujaPrefab;
    public GameObject instanciaPrefabBurbuja;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //desbloqueo para poder lanzar el siguiente proyectil
        if (!cooldown)
        {
            elapsedTime += Time.deltaTime;
        }
        if (elapsedTime > 6f)
        {
            cooldown = true;
            elapsedTime = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {       

        if (collision.gameObject.name == "Jugador")
        {
            if (cooldown)
            {
                Debug.Log("burbuja");
                gameObject.GetComponent<Animator>().Play("concha");
                instanciaPrefabBurbuja = Instantiate(burbujaPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
                cooldown = false;
            }
            
        }
        
    }
    
}
