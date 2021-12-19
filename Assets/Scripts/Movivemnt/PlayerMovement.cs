using System.Collections;
using System.Collections.Generic;

using  UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public GameObject BarraRapida;
    public LogicaBarraSP logicaBarraSP;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale>=1f) {
            Vector2 moviment;
            float movX = Input.GetAxis("Horizontal");
            float movY = Input.GetAxis("Vertical");

            if (movX > 0f)
            {
                movX = 2f;
            }
            if (movX < 0f)
            {
                movX = -2f;
            }
            if (movY > 0f)
            {
                movY = 2f;
            }
            if (movY < 0f)
            {
                movY = -2f;
            }
            //Esto hara  que la barra rapida sea visible o no
            if(movX == 0f && movY == 0f) { 
            BarraRapida.SetActive(true);
            }
            else
            {
               BarraRapida.SetActive(false);
            }
            //Hace que el jugador corra
            if (Input.GetButton("Running") && logicaBarraSP.barraActual >  0)
            {
                logicaBarraSP.Correr();
                
                movY *= 1.5f;
                movX *= 1.5f;

            }
            if(Input.GetButton("Running") && logicaBarraSP.barraActual <= 0)
            {
                print("no pots sprintar");
            }

            moviment = new Vector2(movX, movY);
            rb2d.velocity = moviment;
            
        }
    }
}
