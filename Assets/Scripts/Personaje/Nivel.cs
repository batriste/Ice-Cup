using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel
{
    public int nivelP;
    public int NivelP { get => nivelP; set => nivelP = value; }
    private int nivelMax = 100;
    int experienciaA = 0;
    //Sera la experiencia necesaria para subir de nivel
    private int[] experienciaN;
    public bool subirN = false;
    public bool SubirN { get => subirN; set => subirN = value; }

    public Nivel()
    {
        nivelP = 5;
        experienciaN = new int[nivelMax];
        experienciaN[0] = 0;
        for(int y= 0; y < nivelMax; y++)
        {
            experienciaN[y] = 5 + experienciaN[y];
        }
    }
    // Start is called before the first frame update
    void SubirNivel()
    {
        nivelP++;
        SubirN = true;
    }
    public void GanarExperiencia(int x)
    {
        experienciaA += x;
        if(experienciaA >= experienciaN[nivelP])
        {
            SubirNivel();
            experienciaA -= experienciaN[nivelP];
        }
    }

}
