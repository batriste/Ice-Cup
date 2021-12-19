using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LogicaPantallaCompleta : MonoBehaviour
{
    public Toggle toggle;
    //
    public TMP_Dropdown resolucionesDropDown;
    Resolution[] resoluciones;
    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
        RevisarResolucion();
    }
    
    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions;
        resolucionesDropDown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;
        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);
            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }
        resolucionesDropDown.AddOptions(opciones);
        resolucionesDropDown.value = resolucionActual;
        resolucionesDropDown.RefreshShownValue();
        //Si no ponemos resolucionesDropDown.value = obtenemos el valor de la resolucion actual/guardada se quedara la ultima.
    }
    public void CambiarResolucion(int indiceResolucion)
    {
        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
        //Si no guardamos el valor de la resolucion no tendremos los datos guardados
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
