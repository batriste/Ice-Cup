using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Inventory : MonoBehaviour
{
    //lo usaremos para parar al personaje
    
       
    //Sera el que nos dira si el inventario esta activo o no
    private bool inventoryEnabled;
    //Es el objeto que guarda todo el inventario y lo usaremos para ocultarlo o mostrarlo de la escena
    public GameObject inventory;
    //BarraVyS es la interfaz que desactivaremos para que no molesten a la vista cuando pulsemos  la i
    public GameObject BarraVyS;
    //La cantidad de huecos del inventario
    private int allSlots;
    //El array que almacenara todos los slots y los gestionara
    private GameObject[] slot;
    //El objeto que agrupa todos los slots para asi poder contarlos y recogerlos
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
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled)
        {
            BarraVyS.SetActive(false);
            inventory.SetActive(true);

            Time.timeScale = 0.9f; 
        }
        else
        {
            Time.timeScale = 1f;
            BarraVyS.SetActive(true);
            inventory.SetActive(false);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //farem la  comprovacio  per a que  no  guarde al  enemic com un objecte
        if (other.tag == "Item")
        {
            CogerObjeto(other.gameObject);
        }
        if (other.tag == "Enemy")
        {
            //
            
            //cargamos la partida y pasamos los datos 
            
            SceneManager.LoadScene("Batalla", LoadSceneMode.Single);
            this.enabled = !this.enabled;
            //pasamos los datos.
        }
    }
    public void CogerObjeto(GameObject other)
    {
        if (other.tag == "Item")
        {
            
            Item item = other.GetComponent<Item>();
            AddItem(other, item.ID, item.type, item.descripcion, item.icon);
        }
    }
    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite  itemIcon)
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
                
                //Pondra el objeto  en la posicion de el slot
                itemObject.transform.parent = slot[i].transform;
                //Ocultamos el objeto de la escena  pero lo dejamos en el inventario como un boton.
                itemObject.SetActive(false);

                //Actualizamos la imagen
                slot[i].GetComponent<Slot>().UpdateSlot();

                slot[i].GetComponent<Slot>().empty = false;
                agregado = true;
            }
            
            if (agregado) { return; }
        }
    }

}
