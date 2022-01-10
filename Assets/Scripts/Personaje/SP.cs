using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP
{
    public int spMax = 1;
    public int SpMax { get => spMax; set => spMax = value; }
    public float spActual;
    public float SpActual { get => spActual; set => spActual = value; }
    public float velocidad = 2f;
    public float Velocidad { get => velocidad; set => velocidad = value; }

    
    public SP()
    {
        SpActual = SpMax;
    }

   
}
