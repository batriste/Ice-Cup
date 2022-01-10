using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using  UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    //Para controlar el estado del personaje
    public Personaje personje;
    //Para controlar el cuerpo
    private Rigidbody2D rb2d;
    //AnimarLasPiernas
    //Cuando esta parado
    public GameObject Piernas;
    bool pasos;
    //Moviendose
    public GameObject Piernas1;
    //Moviendose
    public GameObject Piernas2;
    //Saltando
    public GameObject Salto;
    public float tiempo;
    public float tEspera;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause();
        }
        if (personje.estado != "Pausado")
        {
            movimiento();
        }
        else
        {
            
            Vector2 moviment;
            moviment = new Vector2(0f, 0f);
            rb2d.velocity = moviment;
        }


    }
    void Pause()
    {

        
        if (personje.estado != "Pausado")
        {
            personje.estado = "Pausado";

            Debug.Log("Pausant");
            SceneManager.LoadScene("MenuPause", LoadSceneMode.Additive);
            Time.timeScale = 0f;
        }
        else if (personje.estado == "Pausado")
                {
                    personje.estado = "Parado";

                    Debug.Log("Despausant");
                }

    }
    void movimiento()
    {
        
            Vector2 moviment;
            float movX = Input.GetAxis("Horizontal");
            float movY = Input.GetAxis("Vertical");

            if (movX > 0f)
            {
                movX = personje.estamina.velocidad;
                personje.estado = "andando";

            }
            if (movX < 0f)
            {
                movX = -personje.estamina.velocidad;
                personje.estado = "andando";
            }
            if (movY > 0f)
            {
                movY = personje.estamina.velocidad;
                personje.estado = "andando";
            }
            if (movY < 0f)
            {
                movY = -personje.estamina.velocidad;
                personje.estado = "andando";
            }

            //Hace que el jugador corra
            if (Input.GetButton("Running") && personje.estamina.spActual > 0)
            {


                personje.estamina.spActual -= 0.0001f;
                personje.estado = "correr";

                movY *= 1.5f;
                movX *= 1.5f;

            }
            if (Input.GetButton("Running") && personje.estamina.spActual <= 0)
            {
                personje.estado = "cansado";
                print("no pots sprintar");
            }
            if(movX ==0f && movY == 0f)
            {
            personje.estado = "Parado";
            Piernas1.SetActive(false);
            Piernas2.SetActive(false);
            Piernas.SetActive(true);
            //personje.estamina.spActual += 0.00001f;
            }
            if(personje.estado == "andando" || personje.estado == "correr")
            {
            Piernas.SetActive(false);
            
            
            if (tiempo <= 0){
                pasos = !pasos;
                tiempo = tEspera;
            }
                else
            {
                tiempo -= Time.deltaTime;
            }
            if (pasos)
            {
                Piernas1.SetActive(true);
                Piernas2.SetActive(false);
            }
            else
            {
                Piernas1.SetActive(false);
                Piernas2.SetActive(true);
            }
            
            }
            moviment = new Vector2(movX, movY);
            rb2d.velocity = moviment;

        
        
    }

}
