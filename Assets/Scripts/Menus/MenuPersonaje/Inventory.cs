using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    //El personaje para controlar cuando abre el inventario u usa un objeto
    public Personaje personaje;
    
    //El objeto que agrupa todos los slots para asi poder contarlos y recogerlos
    public GameObject slotHolder2;
    //El array que almacenara todos los slots y los gestionara
    private GameObject[] slot2;
    //La cantidad de huecos del inventario
    private int allSlots2;
    public Sprite ico;
    int botonP = 0;
    //Guardaremos los contenedores de armas
    public Transform contArmaD;
    //Array de armas
    GameObject[] armas;
    public Transform contArmaI;
    
    //Array de armas
    GameObject[] armas2;
    //La mira del personaje
    public GameObject mirilla;
    public Transform mira;
    //Objeto que disparamos
    public GameObject bala;
    //Objeto que disparamos
    public GameObject bolaFuego;

    // Start is called before the first frame update
    void Start()
    {
        
        //Definimos el inventario
        allSlots = slotHolder.transform.childCount;
        slot = new GameObject[allSlots];
        
        //Guardamos todos los slots para asi ver si esta vacio o lleno posteriormente para poder usarlo
        for (int i = 0; i < allSlots; i++)
        {
            int x = i;
            
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            slot[i].GetComponent<Button>().onClick.AddListener(() => { //Mover  objeto
                botonsI(x);  });
            
            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
        //Definimos el inventario rapido
        allSlots2 = slotHolder2.transform.childCount;
        slot2 = new GameObject[allSlots2];
        //Guardamos todos los slots para asi ver si esta vacio o lleno posteriormente para poder usarlo
        for (int i = 0; i < allSlots2; i++)
        {
            int x = i;
            slot2[i] = slotHolder2.transform.GetChild(i).gameObject;
            slot2[i].GetComponent<Button>().onClick.AddListener(() => { //Mover  objeto
                botonsF(x);
            });
            if (slot2[i].GetComponent<Slot>().item == null)
            {
                slot2[i].GetComponent<Slot>().empty = true;
            }
        }
        armas = new GameObject[contArmaD.transform.childCount];
        for (int i = 0; i < contArmaD.transform.childCount; i++)
        {
            armas[i] = contArmaD.transform.GetChild(i).gameObject;
        }
        armas2 = new GameObject[contArmaI.transform.childCount];
        for (int i = 0; i < contArmaI.transform.childCount; i++)
        {
            armas2[i] = contArmaI.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Batalla")
        {
            if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled)
        {
            BarraVyS.SetActive(false);
            inventory.SetActive(true);
            personaje.estado = "Pausado";
            Time.timeScale = 0.9f; 
        }
        else
        {
            
            personaje.estado = "Parado";
            Time.timeScale = 1f;
            
            
                BarraVyS.SetActive(true);
                inventory.SetActive(false);
            
            
        }
        //Comprobaremos si se ha pulsado algun boton
        barraRapidaF();
        if(personaje.objetoE == "Espada"  || personaje.objetoE == "Pistola" || personaje.objetoE == "Magia")
        {
            mira.position = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                -Camera.main.transform.position.z)
                );
            //Controlala posicion del arma
            if (armas[0].activeSelf || armas[1].activeSelf || armas[2].activeSelf)
            {
                contArmaD.up = contArmaD.position - mira.position;
            }
            else
            {
                contArmaI.up = contArmaI.position - mira.position;
            }
            
        }

            if (Input.GetButtonDown("Fire1"))
            {
                print("pulsado left click");
                switch (personaje.objetoE)
                {
                    case "nada":
                        {
                            //meteria un puñetazo
                            mirilla.SetActive(false);
                            break;

                        }
                    case "Vegetable":
                        //recuperaremos vida y sp
                        print("vamos a recuperar vida");
                        if (personaje.recuperar(slot2[botonP].GetComponent<Slot>().resultado()))
                        {
                            //El objeto no se puede usar/borrar
                            print("se ha borrat");
                            slot2[botonP].GetComponent<Slot>().icon = ico;
                            slot2[botonP].GetComponent<Slot>().item = null;
                            slot2[botonP].GetComponent<Slot>().UpdateSlot();
                            slot2[botonP].GetComponent<Slot>().empty = true;
                            personaje.objetoE = "nada";
                            mirilla.SetActive(false);
                        }
                        else
                        {
                            print("que pasa asi?");
                        }
                        break;
                    case "Espada":
                        mirilla.SetActive(true);
                        armas[1].SetActive(true);
                        //ataca
                        break;
                    case "Pistola":
                        mirilla.SetActive(true);
                        armas[0].SetActive(true);
                        Disparar();
                        break;
                    case "Magia":
                        mirilla.SetActive(true);
                        armas[2].SetActive(true);
                        Disparar();
                        break;
                }
            }
        }
    }
    void Disparar()
    {
        
        RaycastHit2D hit;
        if (armas[0].activeSelf)
        {
            hit = Physics2D.Raycast(contArmaD.position, (mira.position - contArmaD.position).normalized, 1000f);
            if (personaje.objetoE == "Magia") { Instantiate(bolaFuego, new Vector2(contArmaD.position.x, Random.Range(contArmaD.position.y + 0, contArmaD.position.y - 0)), Quaternion.identity); }
            else
            {
                Instantiate(bala, new Vector2(contArmaD.position.x, Random.Range(contArmaD.position.y + 0, contArmaD.position.y - 0)), Quaternion.identity);
            }
        }
        else
        {
            hit =  Physics2D.Raycast(contArmaI.position, (mira.position - contArmaI.position).normalized, 1000f);
            if (personaje.objetoE == "Magia") { Instantiate(bolaFuego, new Vector2(contArmaI.position.x, Random.Range(contArmaI.position.y + 0, contArmaI.position.y - 0)), Quaternion.identity); }
            else
            {
                Instantiate(bala, new Vector2(contArmaI.position.x, Random.Range(contArmaI.position.y + 0, contArmaI.position.y - 0)), Quaternion.identity);
            }
        }
        if(hit.collider != null)
        {
            //le dio a algo
            
        }
    }
    void barraRapidaF()
    {
        if (Input.GetButton("Button1"))
        {
            if (slot2[0].GetComponent<Slot>().item != null)
            {
                slot2[0].GetComponent<Slot>().ItemEquiped();
                
                GameObject other = slot2[0].GetComponent<Slot>().item;

                Item item = other.GetComponent<Item>();
                personaje.objetoE = item.type;
                //Si es arma se activa

            }
            else
            {
                personaje.objetoE = "nada";
            }
            botonP = 0;
        };
        if (Input.GetButton("Button2"))
        {
            if (slot2[1].GetComponent<Slot>().item != null)
            {
                slot2[1].GetComponent<Slot>().ItemEquiped();

                GameObject other = slot2[1].GetComponent<Slot>().item;

                Item item = other.GetComponent<Item>();
                personaje.objetoE = item.type;
            }
            else
            {
                personaje.objetoE = "nada";
            }
            botonP = 1;
        };
        if (Input.GetButton("Button3"))
        {
            if (slot2[2].GetComponent<Slot>().item != null)
            {
                slot2[2].GetComponent<Slot>().ItemEquiped();

                GameObject other = slot2[2].GetComponent<Slot>().item;

                Item item = other.GetComponent<Item>();
                personaje.objetoE = item.type;
            }
            else
            {
                personaje.objetoE = "nada";
            }
            botonP = 2;
        };
        if (Input.GetButton("Button4"))
        {
            if (slot2[3].GetComponent<Slot>().item != null)
            {
                slot2[3].GetComponent<Slot>().ItemEquiped();

                GameObject other = slot2[3].GetComponent<Slot>().item;

                Item item = other.GetComponent<Item>();
                personaje.objetoE = item.type;
            }
            else
            {
                personaje.objetoE = "nada";
            }
            botonP = 3;
        };
        if (Input.GetButton("Button5"))
        {
            if (slot2[4].GetComponent<Slot>().item != null)
            {
                slot2[4].GetComponent<Slot>().ItemEquiped();

                GameObject other = slot2[4].GetComponent<Slot>().item;

                Item item = other.GetComponent<Item>();
                personaje.objetoE = item.type;
            }
            else
            {
                personaje.objetoE = "nada";
            }
            botonP = 4;
        };
    }
    public void botonsI(int j)
    {
        if (slot[j].GetComponent<Slot>().item != null)
        {
            slot[j].GetComponent<Slot>().empty = true;
            for (int i = 0; i < allSlots2; i++)
            {
                if (slot2[i].GetComponent<Slot>().empty == true)
                {
                    GameObject other = slot[j].GetComponent<Slot>().item;

                    Item item = other.GetComponent<Item>();

                    AddItem2(other, item.ID, item.type, item.descripcion, item.icon);
                    slot[j].GetComponent<Slot>().item = null;
                    slot[j].GetComponent<Slot>().icon = ico;
                    //Actualizamos la imagen
                    slot[i].GetComponent<Slot>().UpdateSlot();

                    return;
                }
            }
            //slot[j].GetComponent<slot>.item

        }

    }
    public void botonsF(int j)
    {
        if (slot2[j].GetComponent<Slot>().item != null)
        {
            slot2[j].GetComponent<Slot>().empty = true;
            for (int i = 0; i < allSlots; i++)
            {
                if (slot[i].GetComponent<Slot>().empty == true)
                {
                    GameObject other = slot2[j].GetComponent<Slot>().item;

                    Item item = other.GetComponent<Item>();

                    AddItem(other, item.ID, item.type, item.descripcion, item.icon);
                    slot2[j].GetComponent<Slot>().item = null;
                    slot2[j].GetComponent<Slot>().icon = ico;
                    //Actualizamos la imagen
                    slot2[i].GetComponent<Slot>().UpdateSlot();
                    slot[i].GetComponent<Slot>().UpdateSlot();
                    return;
                }
            }
            //slot[j].GetComponent<slot>.item

        }
    }
    public void CogerObjeto(GameObject other)
    {
        print(other);
        if (other.tag == "Item")
        {
            
            Item item = other.GetComponent<Item>();
            AddItem(other, item.ID, item.type, item.descripcion, item.icon);
        }
    }
    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite  itemIcon)
    {
        bool agregado = false;
        
        for (int i = 0; i < allSlots; i++)
        {
            
            //Aqui veriamos si el slot esta vacio
            
            if (slot[i].GetComponent<Slot>().empty)
            {
                //itemObject.GetComponent<Item>().pickedUp = true;
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
    public void AddItem2(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        bool agregado = false;

        for (int i = 0; i < allSlots2; i++)
        {

            //Aqui veriamos si el slot esta vacio

            if (slot2[i].GetComponent<Slot>().empty)
            {
                //Se usara cuando se pulse el boton
                //itemObject.GetComponent<Item>().pickedUp = true;
                slot2[i].GetComponent<Slot>().item = itemObject;
                slot2[i].GetComponent<Slot>().ID = itemID;
                slot2[i].GetComponent<Slot>().type = itemType;
                slot2[i].GetComponent<Slot>().descripcion = itemDescription;
                slot2[i].GetComponent<Slot>().icon = itemIcon;

                //Pondra el objeto  en la posicion de el slot
                itemObject.transform.parent = slot[i].transform;
                //Ocultamos el objeto de la escena  pero lo dejamos en el inventario como un boton.
                itemObject.SetActive(false);

                //Actualizamos la imagen
                slot2[i].GetComponent<Slot>().UpdateSlot();

                slot2[i].GetComponent<Slot>().empty = false;
                agregado = true;
            }

            if (agregado) { return; }
        }
    }

}
