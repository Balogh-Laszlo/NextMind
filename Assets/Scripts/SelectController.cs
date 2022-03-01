using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// [RequireComponent(typeof(LoadScript))]
public class SelectController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Controller> controllers = null;
    private List<Controller> controllersOnScreen;
    private int currentPage = 0;
    // public LoadScript loader;
    private List<string> controllerNames;
    public string loadPath;
    public GameObject nextPageMindButton;
    
    
    private void Awake()
    {
        Debug.Log("AWAKE");
        loadPath = Application.persistentDataPath + "/myControllers2.save";
        // loader = GetComponent<LoadScript>();
        // loader.LoadData();
        LoadData();
        Debug.Log("Data Loaded");
    }

    void Start()
    {
        controllersOnScreen = new List<Controller>();
        Debug.Log("START");
        Debug.Log(controllers.Count);
        controllerNames = new List<string>();
        for (int i = 0; i < controllers.Count; i++)
        {
            controllerNames.Add(controllers[i].controllerName);
        }

        if (controllers.Count>5)
        {
            nextPageMindButton.SetActive(true);
            for (int i = 0; i < 5; ++i)
            {
                controllersOnScreen.Add(controllers[i]);
            }
        }
        else
        {
            nextPageMindButton.SetActive(false);
            controllersOnScreen = controllers;
        }
        Debug.Log("Controllers on screen: "+controllersOnScreen.Count);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadData()
    {
        if (File.Exists(loadPath))
        {
            Save save;
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(loadPath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }

            controllers = save.controllers;
        }
    }

    public void onBackPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void nextPage()
    {
        currentPage += 1;
        controllersOnScreen.Clear();
        int temp = currentPage * 5;
        for (int i = temp; i < temp+5; i++)
        {
            if (i < controllers.Count)
            {
                controllersOnScreen.Add(controllers[i]);
            }
            else
            {
                break;
            }
            
        }
    }
}
