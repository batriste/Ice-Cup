using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogicaNivel : MonoBehaviour
{
    //Estara asignado al objeto de nivel
    Text tNivel;
    private Personaje peronaje;
    int nivel;
    // Start is called before the first frame update
    void Start()
    {
        tNivel = GetComponent<Text>();
        peronaje = GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(Personaje)) as Personaje;
    }

    // Update is called once per frame
    void Update()
    {
        nivel = peronaje.nivel.nivelP;
        
        tNivel.text = "Nivel: " + peronaje.nivel.nivelP;
    }
}
