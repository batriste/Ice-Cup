using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastInventory : MonoBehaviour
{
    private bool inventoryEnabled;
    //Es el objeto que guarda todo el inventario
    public GameObject inventory;
    
    private int allSlots;
    private int enabledSlots;
    //cada espacio si esta vacio
    private GameObject[] slot;
    //Sera la cantidad de espacios
    public GameObject slotHolder;
    // Start is called before the first frame update
    void Start()
    {
        
        allSlots = slotHolder.transform.childCount;
        slot = new GameObject[allSlots];
        //Guardamos todos los slots para asi ver si esta vacio o lleno posteriormente para poder usarlo
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Podriamos  poner  que con la q y la e cambiara de objeto de la barra 
    }
  /*No hace falta porque los objetos van del inventario a la mano
    public void CogerObjeto(GameObject other)
    {
        if (other.tag == "Item")
        {

            Item item = other.GetComponent<Item>();
            AddItem(other, item.ID, item.type, item.descripcion, item.icon);
        }
    }
    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        bool agregado = false;
        print(allSlots);
        for (int i = 0; i < allSlots; i++)
        {
            print(allSlots);
            //Aqui veriamos si el slot esta vacio
            print(i);
            if (slot[i].GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().descripcion = itemDescription;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);


                //Actualizamos la imagen
                slot[i].GetComponent<Slot>().UpdateSlot();

                slot[i].GetComponent<Slot>().empty = false;
                agregado = true;
            }

            if (agregado) { return; }
        }
    }
  */
}
