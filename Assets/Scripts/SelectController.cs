using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// [RequireComponent(typeof(LoadScript))]
public class SelectController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Controller> controllers = null;
    // public LoadScript loader;
    public Text text;
    public TMP_Dropdown options;
    private List<string> controllerNames;
    public string loadPath;

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
        Debug.Log("START");
        Debug.Log(controllers.Count);
        controllerNames = new List<string>();
        for (int i = 0; i < controllers.Count; i++)
        {
            controllerNames.Add(controllers[i].controllerName);
        }

        if (options != null)
        {
            options.ClearOptions();
            options.AddOptions(controllerNames);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool isLoaded()
    {
        if (controllers != null)
        {
            return true;
        }

        return false;

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
}
