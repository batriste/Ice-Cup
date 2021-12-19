using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estadisticas : MonoBehaviour
{
    private int HPmax = 100;
    private int HPactual = 100;

    private int nivel = 1;
    private int dmg = 10;
    private int defensa = 5;
    private int velocidad = 2;

    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Defensa { get => defensa; set => defensa = value; }
    public int Dmg { get => dmg; set => dmg = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int VPactual { get => HPactual; set => HPactual = value; }
    public int VPmax { get => HPmax; set => HPmax = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
