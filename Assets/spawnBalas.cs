using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBalas : MonoBehaviour
{
    public GameObject element;
    private float tiempo;
    public float tEspera;
    public float limit;
    void Update()
    {
        if (tiempo <= 0)
        {
            Instantiate(element, new Vector2(transform.position.x, Random.Range(transform.position.y + limit, transform.position.y - limit)), Quaternion.identity);
            tiempo = tEspera;
        }
        else
        {
            tiempo -= Time.deltaTime;
        }
    }
    
}
