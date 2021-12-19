using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Inventory inv;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private GameObject ObjectDetectRayCast()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position,2,transform.forward);
        foreach(RaycastHit2D h in hit){
            if(h.transform.tag == "Item")
            {
                return h.transform.gameObject;
            }
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        GameObject item = ObjectDetectRayCast();
        if(item != null && Input.GetButtonDown("Fire2"))
        {
            print(item);
            inv.CogerObjeto(item.gameObject);
            
        }

    }
}
