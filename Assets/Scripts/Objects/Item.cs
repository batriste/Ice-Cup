using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    //El tipo del objeto la ponemos en el prefab
    public string type = "nada";
    //La descripcion del objeto la ponemos en el prefab
    public string descripcion;
    public Sprite icon;
    //Sera la cantidad de puntos que subira
    public int valor;
    
    [HideInInspector]
    public bool equipped;
    
    [HideInInspector]
    public GameObject tool;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (equipped)
        {

            if (Input.GetButtonDown("Fire1"))
            {
                
            }
            
        }
    }
    public int ItemUsage()
    {
        return valor;

    }
}
