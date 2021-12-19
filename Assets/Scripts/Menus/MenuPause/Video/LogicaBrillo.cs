using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogicaBrillo : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image panelBrillo;
    // Start is called before the first frame update
    void Start()
    {
        //Podriamos tener un objeto que tenga las variables globales de todos los controles
        slider.value = 0.5f;
        //Tocamos el valor de A para el brillo
        //panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value);
    }
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        //panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value);
        //Podriamos guardar el nuevo valor de la variable global
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
