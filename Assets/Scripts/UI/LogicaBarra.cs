using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogicaBarra : MonoBehaviour
{
    public int barraMax;
    public float barraActual;
    public Image imagenBarra;

    public float BarraActual { get => barraActual; set => barraActual = value; }

    // Start is called before the first frame update
    void Start()
    {
        barraActual = barraMax;
    }

    // Update is called once per frame
    void Update()
    {
        print(barraActual);
        RevisarBarra();
        
    }

    public void RevisarBarra() {
        imagenBarra.fillAmount = barraActual / barraMax;
    }
}
