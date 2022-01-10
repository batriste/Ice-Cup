using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaVE : MonoBehaviour
{
    Vector2 espacio;
    private Enemic enemic;
    // Start is called before the first frame update
    void Start()
    {
        enemic = GameObject.FindGameObjectWithTag("Enemic").GetComponent(typeof(Enemic)) as Enemic;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemic.estado == "danyo"){
            transform.localScale = new Vector3(enemic.vida.hpActual, 0, 0);
            enemic.estado = "nada";
        }
        
    }
}
