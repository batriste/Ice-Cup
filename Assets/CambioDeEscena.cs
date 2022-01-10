using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    //La  A es de aliado y la E de enemigo
    public Transform puntoInicialA;
    public Transform puntoInicialE;
    public GameObject personjeA;
    public Personaje personje; 
    public GameObject personjeE;
    public Enemic enemic;
    string levelName;
    //Nivel del player
    public GameObject nivelUI;
    public GameObject nivelEUI;
    //ImagesBarresVida
    public Image imagenBarraA;
    public Image imagenBarraE;
    //La cantidad de botones de ataque fisico
    private int allSlots;
    //El array que almacenara todos botones
    private GameObject[] ataqueF;
    //El objeto que agrupa todos los botones para asi poder contarlos y recogerlos
    public GameObject slotHolder;
   
    //El array que almacenara todos botones
    private GameObject[] ataqueM;
    //El objeto que agrupa todos los botones para asi poder contarlos y recogerlos
    public GameObject slotHolder2;
    // Start is called before the first frame update
    void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
        /*Obsolet
         * levelName = Application.loadedLevelName;
        print(levelName);*/
        if (levelName  == "Batalla")
        {
            personjeA = GameObject.FindGameObjectWithTag("Player");
            personje = GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(Personaje)) as Personaje;
            
            personjeE = GameObject.FindGameObjectWithTag("Enemy");
            enemic = GameObject.FindGameObjectWithTag("Enemy").GetComponent(typeof(Enemic)) as Enemic;
            puntoInicialA = GameObject.FindGameObjectWithTag("PuntoInicialA").transform;
            puntoInicialE = GameObject.FindGameObjectWithTag("PuntoInicialE").transform;
            Time.timeScale = 0.9f;
            MoverAPuntoInicial();
            allSlots = slotHolder.transform.childCount;
            ataqueF = new GameObject[allSlots];
            ataqueM = new GameObject[allSlots];
            for (int i = 0; i < allSlots; i++)
            {
                int x = i;

                ataqueF[i] = slotHolder.transform.GetChild(i).gameObject;
               ataqueF[i].GetComponent<Button>().onClick.AddListener(() => { //Mover  objeto
                    botonsF(x);
                });
                ataqueM[i] = slotHolder.transform.GetChild(i).gameObject;
                ataqueM[i].GetComponent<Button>().onClick.AddListener(() => { //Mover  objeto
                    botonsM(x);
                });


            }
        }
        
    }
    void botonsF(int x)
    {
       switch(x)
        {
            case 0:
                personje.bajarVida( 0.5f);
                enemic.bajarVida(0.5f);

                break;
            case 1:
                personje.bajarVida(0.10f);
                enemic.bajarVida(0.15f);
                break;
            case 2:
                personje.bajarVida(0.40f);
                enemic.bajarVida(0.30f);
                break;
            case 3:
                personje.bajarVida(0.5f);
                enemic.bajarVida(0.20f);
                break;
            default:
                break;
        }
    }
    void botonsM(int x)
    {
        switch (x)
        {
            case 0:
                personje.bajarVida(0.5f);
                enemic.bajarVida(0.5f);

                break;
            case 1:
                personje.bajarVida(0.10f);
                enemic.bajarVida(0.15f);
                break;
            case 2:
                personje.bajarVida(0.40f);
                enemic.bajarVida(0.30f);
                break;
            case 3:
                personje.bajarVida(0.5f);
                enemic.bajarVida(0.20f);
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (personje = null) {
            RevisarBarra();
        }
        

    }
    public void RevisarBarra()
    {
        float x = personje.vida.hpActual / personje.vida.hpMax;

        imagenBarraA.fillAmount = x;
        float y = enemic.vida.hpActual / enemic.vida.hpMax;
        imagenBarraE.fillAmount = x;
    }
    public void MoverAPuntoInicial()
    {
        personjeA.transform.position = puntoInicialA.position;
        personjeE.transform.position = puntoInicialE.position;

    }
}
