using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
[RequireComponent(typeof(SelectController))]
public class LoadScript : MonoBehaviour
{
    public SelectController SelectController;
    public string loadPath;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LoadStarted");
        SelectController = GetComponent<SelectController>();
        loadPath = Application.persistentDataPath + "/myControllers2.save";
        LoadData();
        Debug.Log("LoadEnded");
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

            SelectController.controllers = save.controllers;
        }
    }
}
