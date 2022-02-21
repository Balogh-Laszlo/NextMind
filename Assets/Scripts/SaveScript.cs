using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
[RequireComponent(typeof(NewController))]
public class SaveScript : MonoBehaviour
{
    private NewController newController;
    private string savePath;
    
    // Start is called before the first frame update
    void Start()
    {
        newController = GetComponent<NewController>();
        savePath = Application.persistentDataPath + "/Controllers.save";
    }

    public void SaveData()
    {
        var controller = new Controller()
        {
            controllerName = newController.name,
            controls = newController.controls,
            IFTTTKey = newController.key,
            numberOfPages = newController.numberOfPages
        };
        var binaryFormatter = new BinaryFormatter();
        if (File.Exists(savePath))
        {
            var save = new Save();
            using (var fileStream = File.Open(savePath,FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }
            save.controllers.Add(controller);
            using (var fileStream = File.Create(savePath))
            {
                binaryFormatter.Serialize(fileStream,save);
            }
        }
        else
        {
            var save = new Save()
            {
                controllers = new List<Controller> {controller}
            };
            using (var fileStream = File.Create(savePath))
            {
                binaryFormatter.Serialize(fileStream,save);
            }
        }
        
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            Save save;
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }
            Debug.Log(save.controllers.Count);
        }
    }
}
