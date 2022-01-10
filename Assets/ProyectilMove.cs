using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilMove : MonoBehaviour
{
    private Rigidbody2D element;
    public float thrust = 2.5f;
    public bool movingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        element = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movingLeft)
        {
            element.velocity = new Vector2(thrust * -1, thrust * 0f);
        }
        else
        {
            element.AddForce(new Vector2(thrust, 0f));
        }
    }
}
