using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyD
{
    int Ataque;
    int Defensa;
    float Resultado;
    
    // Start is called before the first frame update
    public AyD()
    {
        Ataque = 5;
        Defensa = 0;
    }
    /*
     * Se pasan dos valores que seran los extra para el ataque
     */
    public float ResultadoAtaque(float x)
    {
        Resultado = x - Defensa;
        return Resultado;
    }
    
}
