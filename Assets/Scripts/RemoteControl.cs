using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemoteControl : MonoBehaviour
{
    public TMP_Text name;
    public Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        if (SelectController.currentController != null)
        {
            controller = SelectController.currentController;
            name.text = controller.controllerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
