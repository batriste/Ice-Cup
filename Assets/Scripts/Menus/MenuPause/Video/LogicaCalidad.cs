using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LogicaCalidad : MonoBehaviour
{
    public TMP_Dropdown desplegable;
    public int calidad;
    // Start is called before the first frame update
    void Start()
    {
        desplegable.value = calidad;
        AjustarCalidad();

    }
    public void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(desplegable.value);
        calidad = desplegable.value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
