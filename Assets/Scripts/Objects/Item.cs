using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    //El tipo del objeto la ponemos en el prefab
    public string type;
    //La descripcion del objeto la ponemos en el prefab
    public string descripcion;
    public Sprite icon;
    
    [HideInInspector]
    public bool pickedUp;

    public bool equipped;
    
    [HideInInspector]
    public GameObject tool;
    public bool playerWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (equipped)
        {

        }
    }
    public void ItemUsage()
    {
        if (type=="Item")
        {
            equipped = true;
        }
    }
}
