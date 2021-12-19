using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestruir : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private  void Awake()
    {
        var noDestruirEntreEscenas = FindObjectsOfType<NoDestruir>();
        if (noDestruirEntreEscenas.Length> 2)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
