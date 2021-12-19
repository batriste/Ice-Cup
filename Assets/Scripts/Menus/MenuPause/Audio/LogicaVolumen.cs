using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaVolumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;
    // Start is called before the first frame update
    void Start()
    {
        //Podriamos tener un objeto que controle todos los valores medios
        //slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        slider.value = 0.5f;
        AudioListener.volume = slider.value;
        EstarMuted();
    }
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        
        AudioListener.volume = slider.value;
        EstarMuted();
    }

    public void EstarMuted()
    {
        if (sliderValue == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }
}

