using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuControler : MonoBehaviour
{
   
        //Si volem fer algo mes amb els botons podriem pero sols els deixem de moment per  a activar els menus
    public Button OptionsVButton = null;
    public Button OptionsAButton = null;
    public Button OptionsJButton = null;
    public Button ContinueButton1 = null;
    public Button ContinueButton2 = null;
    public Button ContinueButton3 = null; 
    public Button ContinueButton4 = null;
    public Button QuitButton1 = null;
    public Button QuitButton2 = null;
    public Button QuitButton3 = null;
    public Button QuitButton4 = null;
    // Start is called before the first frame update
    void Start()
    {
        OptionsVButton.onClick.AddListener(() =>
        {
        });
        OptionsAButton.onClick.AddListener(() =>
        {
        });
        OptionsJButton.onClick.AddListener(() =>
        {
        });
        ContinueButton1.onClick.AddListener(() =>
        {
            
            Continuar();
        });
        ContinueButton2.onClick.AddListener(() =>
        {

            Continuar();
        });
        ContinueButton3.onClick.AddListener(() =>
        {

            Continuar();
        });
        ContinueButton4.onClick.AddListener(() =>
        {

            Continuar();
        });
        QuitButton1.onClick.AddListener(() =>
        {
            Salir();
        });
        QuitButton2.onClick.AddListener(() =>
        {
            Salir();
        });
        QuitButton3.onClick.AddListener(() =>
        {
            Salir();
        });
        QuitButton4.onClick.AddListener(() =>
        {
            Salir();
        });
        
    }
    void Salir()
    {
        Debug.Log("Ixint");
        Application.Quit();
    }
    void Continuar()
    {
        Debug.Log("continuant");
        SceneManager.UnloadSceneAsync("MenuPause");
        
    }
   

        // Update is called once per frame
        void Update()
    {
        
        
        if (Input.GetButtonDown("Pause"))
        {
            
            SceneManager.UnloadSceneAsync("MenuPause");
            //
            Debug.Log("Despausant apretant esc");
           
        }
    }
}
