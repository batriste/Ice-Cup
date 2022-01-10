using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InicioButtons : MonoBehaviour
{
    public string empezar;
    public string opciones;
    public Button StartButton = null;
    

    public Button OptionsButton = null;
    public Button ExitButton = null;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(() =>
        {

            Empezar();
        });
       
        OptionsButton.onClick.AddListener(() =>
        {

            Options();
        });
        ExitButton.onClick.AddListener(() =>
        {

            Salir();
        });
    }
    void Empezar()
    {
        Debug.Log("Empezamos");
        LoadScene(empezar);
     
    }
  
    void Options()
    {
        Debug.Log("Options");
        LoadScene(opciones);
    }
    void Salir()
    {
        Debug.Log("Ixint");
        Application.Quit();
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    // Update is called once per frame

}
