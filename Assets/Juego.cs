using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class Juego : MonoBehaviour
{
    //Tiene el nivel del personaje
    public int nivel;
    //Sera asi para poder llamar a las variables que guardemos desde los eventos.
    public static Juego juego;
    //La ruta + el nombre del archivo
    private String rutaArchivo;
    void Awake()
    {
        rutaArchivo = Application.persistentDataPath + "/icecup.dat";
        if (juego == null)
        {
            juego = this;
            DontDestroyOnLoad(gameObject);
        }else if (juego != this)
        {
            Destroy(gameObject);
        }
    }
    void Guardar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(rutaArchivo);
        DatosG datos = new DatosG();
        datos.puntuacionMaxima = nivel;
        bf.Serialize(file, datos);
        file.Close();
    }
    void Cargar()
    {
        if (File.Exists(rutaArchivo))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(rutaArchivo, FileMode.Open);
            DatosG datos = (DatosG)bf.Deserialize(file);
            nivel = datos.puntuacionMaxima;
            file.Close;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[Serializable]
public class DatosG
{
    public int puntuacionMaxima;
}
