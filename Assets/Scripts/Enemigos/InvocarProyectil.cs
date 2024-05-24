using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvocarProyectil : MonoBehaviour
{
    private float startDelay = 1f;
    public float repeatRate = 10f;
    public GameObject balaPrefab;
    public GameObject instanciaPrefabBala;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RepeatedAction", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        //instanciaPrefabBala = Instantiate(balaPrefab, transform.position + new Vector3(0, -5f, 0), Quaternion.identity);
    }
    void RepeatedAction()
    {
        instanciaPrefabBala = Instantiate(balaPrefab, transform.position + new Vector3(0, -5f, 0), Quaternion.identity);
    }
}
