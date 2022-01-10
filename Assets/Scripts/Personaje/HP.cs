using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP
{
    public int hpMax = 1;
    public int HpMax { get => hpMax; set => hpMax = value; }
    public float hpActual;
    public float HpActual { get => hpActual; set => hpActual = value; }
    

    public HP()
    {
        HpActual = HpMax;
    }

    
}
