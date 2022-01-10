using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemic : MonoBehaviour
{
    public HP vida;
    public SP estamina;
    public AyD ataqueydefensa;
    public Nivel nivel;
    public string estado;
    // Start is called before the first frame update
    void Start()
    {
        estado = "parado";

        nivel = new Nivel();

        vida = new HP();
        estamina = new SP();
        ataqueydefensa = new AyD();
    }

    // Update is called once per frame
    void Update()
    {
        if(vida.hpActual == 0f)
        {
            Destroy(gameObject);
        }
            
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Danyo")
        {
            estado = "danyo";
            bajarVida(ataqueydefensa.ResultadoAtaque(0.1f));

        }
        if (other.tag == "Bala")
        {
            estado = "danyo";
            bajarVida(ataqueydefensa.ResultadoAtaque(0.1f));
            Destroy(other);

        }

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
    void Awake()
    {
        Enemic objecte = null;
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
