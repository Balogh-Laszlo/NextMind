using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{
    // Start is called before the first frame update
    private static string key = "";
    private const string baseURL = "https://maker.ifttt.com/trigger/";
    private const string endURL = "/json/with/key/";

    public GameObject IFTTTkeyCanvas;
    public GameObject Controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onNextPressed()
    {
        Debug.Log(key.Length);
        if (key.Length<1)
        {
            Debug.Log("Insert the IFTTT key!");
        }
        else
        {
            IFTTTkeyCanvas.SetActive(false);
            Controller.SetActive(true);
        }
        
    }

    public void saveIFTTTkeyInput(string s)
    {
        key = s;
        Debug.Log(s);
    }
}
