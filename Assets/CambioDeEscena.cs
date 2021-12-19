using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioDeEscena : MonoBehaviour
{
    //La  A es de aliado y la E de enemigo
    public Transform puntoInicialA;
    public Transform puntoInicialE;
    public GameObject personajeA;
    public GameObject personajeE;
    string levelName;
    // Start is called before the first frame update
    void Start()
    {
        levelName = Application.loadedLevelName;
        print(levelName);
        if (levelName  == "Batalla")
        {
            personajeA = GameObject.FindGameObjectWithTag("Player");
            personajeE = GameObject.FindGameObjectWithTag("Enemy");
            puntoInicialA = GameObject.FindGameObjectWithTag("PuntoInicialA").transform;
            puntoInicialE = GameObject.FindGameObjectWithTag("PuntoInicialE").transform;
            Time.timeScale = 0.9f;
            MoverAPuntoInicial();
        }
        
    }

    // Update is called once per frame
    /*void Update()
    {
        ProbarCambioDeEscena();
    }*/
    public void MoverAPuntoInicial()
    {
        personajeA.transform.position = puntoInicialA.position;
        personajeE.transform.position = puntoInicialE.position;

    }
}
