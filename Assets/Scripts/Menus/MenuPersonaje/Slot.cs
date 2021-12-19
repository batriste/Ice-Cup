using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slot : MonoBehaviour//, IPointerClickHandler
{
    //item hará referencia al objeto dentro de la escena.
    public GameObject item = null;
    //Es el identificador del objeto.
    public int ID;
    //Es el tipo del objeto el cual usaremos para diferenciar los grupos a la hora de usar el mismo
    public string type;
    //Una descripcion del articulo
    public string descripcion;
    //Si esta vacio
    public bool empty;
    //El icono del objeto
    public Sprite icon;
    //Es donde posicionaremos la imagen del objeto
    public Transform slotIconGameObject;
    
    
    public void Start()
    {
      

        slotIconGameObject = transform.GetChild(0);
    }
    public void UpdateSlot()
    {
        slotIconGameObject.GetComponent<Image>().sprite = icon;
    }
    /*public void OnPointerClick(PointerEventData pointerEventData)
    {
        empty = false;
        
        //if(slotHolder.transform.childCount <=10 && Input.GetButtonDown("Fire1")) UseItem();
        
    }*/
    
    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();
        
    }
    
}
