public class LogicaBarraSP : LogicaBarra
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
     void Update()
    {
        
        RevisarBarra();
    }


    public void Correr()
    {
        
        this.barraActual -= 0.01f;
    }
}
