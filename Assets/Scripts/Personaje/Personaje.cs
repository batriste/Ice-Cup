using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Personaje : MonoBehaviour
{
    public HP vida;
    public SP estamina;
    public AyD ataqueydefensa;
    public Nivel nivel;

    public string estado;
    public string objetoE = "nada";

    //El personaje debe poder controlar el inventario y recoger objetos.
    public Inventory inv;
    // Start is called before the first frame update
    void Start()
    {
        estado = "parado";
        
        nivel = new Nivel();
        
        vida = new HP();
        estamina = new SP();
        ataqueydefensa = new AyD();
    }

    // Podria cargar las animaciones
    void Update()
    {

        
       
       
        if (Time.timeScale == 1f)
        {
            //Detectar objetos
            Detectado();
            if (nivel.subirN)
            {
                SubirNivel();

            }
            if (Fin())
            {
                //final partida
                SceneManager.LoadScene("Final", LoadSceneMode.Single);
            }
            nivel.GanarExperiencia(0);
        }
           
    }
    //Detecta si hay objetos cerca
    void Detectado()
    {
        GameObject item = ObjectDetectRayCast();
        //Click izquierdo +que exista un  objeto
        if (item != null && Input.GetButtonDown("Fire2"))
        {
            print(item);
            inv.CogerObjeto(item.gameObject);

        }
    }
    //El area del jugador
    private GameObject ObjectDetectRayCast()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 2, transform.forward);
        foreach (RaycastHit2D h in hit)
        {
            if (h.transform.tag == "Item")
            {
                return h.transform.gameObject;
            }
        }
        return null;
    }
    //La colision del jugador
    public void OnTriggerEnter2D(Collider2D other)
    {
        //farem la  comprovacio  per a que  no  guarde al  enemic com un objecte
        if (other.tag == "Item")
        {
            inv.CogerObjeto(other.gameObject);
        }
        if (other.tag == "Daño")
        {
            bajarVida(ataqueydefensa.ResultadoAtaque(0.3f));

        }

            if (other.tag == "Enemy")
        {
            //

            //cargamos la partida y pasamos los datos 
            estado = "Batalla";
            SceneManager.LoadScene("Batalla", LoadSceneMode.Single);
            
            //pasamos los datos.
        }
    }
    //Para que el personaje le suban las estadisticas
    void SubirNivel()
    {
        //subimos vida
        vida.hpMax += 1;
        vida.HpActual = vida.hpMax;
        //subimos estamina
        estamina.spMax += 1;
        estamina.spActual = estamina.spMax;
        estamina.velocidad += 0.1f;
        //subimos ataque
        //subimos defensa
        nivel.subirN = false;
    }
    //Para poder pausar en todo momento el juego
    public bool recuperar(int i)
    {
        
        switch(i){
            case 1:
                print("fins asi arribe " + i);
                return recuperarVyE(0.25f);
            break;
            case 2:
                print("fins asi arribe " + i);
                return recuperarVyE(0.50f);
            break;
            case 3:
                print("fins asi arribe " + i);
                return recuperarVyE(0.75f);
           
            break;
            default:
                print("Incorrect intelligence level.");
                return false;
                break;
        }
        return false;
    }
    
    public void bajarVida(float u)
    {
        
        
        
            float f = 0;
            do
            {
                f += 0.0001f;
                
                
                     vida.hpActual -= 0.001f;

                    
                
            } while (f < u);

           
        
    }
    bool recuperarVyE(float u)
    {
        print("hola");
        if (vida.hpActual >= 1f && estamina.spActual >= 1f)
        {
            print("no se borra");
            return false;
        }
        else
        {
            float f = 0;
            do
            {
                f += 0.001f;
                if (vida.hpActual >= 1f && estamina.spActual >= 1f)
                {
                    print("Se borra perk si");
                    return true;
                }
                else
                {
                    print(f);
                    if (vida.hpActual < 1f) vida.hpActual += 0.001f;

                    if (estamina.spActual < 1f) estamina.spActual += 0.001f;
                }
            } while (f < u);
            
            print("sesborra");
            return true;
        }
    }
    bool Fin()
    {
        if (vida.hpActual <= 0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Awake()
    {
        Personaje objecte = null;
        if (objecte != null)
        {
            Debug.Log(objecte);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log(objecte);
            objecte = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

}
