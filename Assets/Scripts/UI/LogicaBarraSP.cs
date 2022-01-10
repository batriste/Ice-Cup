/*public class LogicaBarraSP : LogicaBarra
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
     void Update()
    {
        
        RevisarBarra();
    }


    public void Correr()
    {
        
        this.barraActual -= 0.01f;
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBarraSP : MonoBehaviour
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
        float x = personje.estamina.spActual /personje.estamina.spMax ;
        
        imagenBarra.fillAmount = x;
    }
}