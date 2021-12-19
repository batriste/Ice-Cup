using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            
            if (Time.timeScale == 0f)
            {
                
                Time.timeScale = 1f;
                Debug.Log("Despausant");
            }
            else if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
                Debug.Log("Pausant");
                SceneManager.LoadScene("MenuPause", LoadSceneMode.Additive);
            }
        }
    }
}
