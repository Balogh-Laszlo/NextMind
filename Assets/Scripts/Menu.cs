using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void calibrateDevice()
    {
        SceneManager.LoadScene(1);
    }

    public void newController()
    {
        SceneManager.LoadScene(11);
    }

    public void selectController()
    {
        SceneManager.LoadScene(12);
    }
}
