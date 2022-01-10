using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBarraVida : MonoBehaviour 
{ 
    public Image imagenBarra;
    private Personaje personje;
    void Start()
    {

        personje = GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(Personaje)) as Personaje;
    }
    void Update()
    {
        
        RevisarBarra();

    }
    public void RevisarBarra()
    {
        imagenBarra.fillAmount = personje.vida.hpActual / personje.vida.hpMax ;
    }
}

