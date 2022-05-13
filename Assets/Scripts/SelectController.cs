using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NextMind;
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

    public static Controller currentController;
    // public LoadScript loader;
    private List<string> controllerNames;
    public string loadPath;
    public GameObject nextPageMindButton;
    public GameObject prevPageButton;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    private List<GameObject> buttons;
    //public NeuroManager neuroManager;



    private void Awake()
    {
        Debug.Log("AWAKE");
        loadPath = Application.persistentDataPath + "/myControllers3.save";
        // loader = GetComponent<LoadScript>();
        // loader.LoadData();
        LoadData();
        Debug.Log("Data Loaded");
    }

    void Start()
    {
        //Debug.Log(neuroManager.Devices.Count);
        controllersOnScreen = new List<Controller>();
        buttons = new List<GameObject>() {button1, button2, button3, button4, button5};
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
                TMP_Text temp = buttons[i].GetComponentInChildren<TMP_Text>();
                if (temp != null)
                {
                    temp.text = controllers[i].controllerName;
                }
            }
        }
        else
        {
            nextPageMindButton.SetActive(false);
            controllersOnScreen = controllers;
            for (int i = 0; i < controllers.Count; i++)
            {
                
                TMP_Text temp = buttons[i].GetComponentInChildren<TMP_Text>();
                if (temp != null)
                {
                    temp.text = controllers[i].controllerName;
                }
            }

            for (int i = controllers.Count; i < 5; ++i)
            {
                buttons[i].SetActive(false);
            }
        }
        Debug.Log("Controllers on screen: "+controllersOnScreen.Count);
        if (currentPage == 0)
        {
            prevPageButton.SetActive(false);
        }

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
        //foreach (var device in neuroManager.Devices)
        //{
            //neuroManager.DisconnectDevice(device);
        //}
        DontDestroyOnLoad(GameObject.Find("NeuroManager"));
        SceneManager.LoadScene(1);
        
    }

    public void nextPage()
    {
        currentPage += 1;
        if (prevPageButton.activeSelf == false)
        {
            prevPageButton.SetActive(true);
        }
        if (currentPage >= controllers.Count / 5)
        {
            nextPageMindButton.SetActive(false);
        }
        controllersOnScreen.Clear();
        int temp = currentPage * 5;
        int buttonIndex = 0;
        for (int i = temp; i < temp+5; i++)
        {
            if (i < controllers.Count)
            {
                if (buttons[buttonIndex].activeSelf == false)
                {
                    buttons[buttonIndex].SetActive(true);
                }
                controllersOnScreen.Add(controllers[i]);
                TMP_Text text = buttons[buttonIndex].GetComponentInChildren<TMP_Text>();
                if (text != null)
                {
                    text.text = controllers[i].controllerName;
                }
            }
            else
            {
                buttons[buttonIndex].SetActive(false);
            }

            buttonIndex++;

        }
    }

    public void prevPage()
    {
        currentPage -= 1;
        if (nextPageMindButton.activeSelf == false)
        {
            nextPageMindButton.SetActive(true);
        }

        if (currentPage == 0)
        {
            prevPageButton.SetActive(false);
        }
        controllersOnScreen.Clear();
        int temp = currentPage * 5;
        int buttonIndex = 0;
        for (int i = temp; i < temp+5; i++)
        {
            if (i < controllers.Count)
            {
                controllersOnScreen.Add(controllers[i]);
                if (buttons[buttonIndex].activeSelf == false)
                {
                    buttons[buttonIndex].SetActive(true);
                }
                TMP_Text text = buttons[buttonIndex].GetComponentInChildren<TMP_Text>();
                if (text != null)
                {
                    text.text = controllers[i].controllerName;
                }
            }
            else
            {
                buttons[buttonIndex].SetActive(false);
            }

            buttonIndex++;

        }
    }

    public void onButton1Pressed()
    {
        Debug.Log(controllers[currentPage*5+0].controllerName);
        currentController = controllers[currentPage*5];
        onControllerSelectedCommon(currentController);
    }

    public void onButton2Pressed()
    {
        Debug.Log(controllers[currentPage*5+1].controllerName);
        currentController = controllers[currentPage*5 + 1];
        onControllerSelectedCommon(currentController);
    }

    public void onButton3Pressed()
    {
        Debug.Log(controllers[currentPage*5+2].controllerName);
        currentController = controllers[currentPage*5 + 2];
        onControllerSelectedCommon(currentController);
    }

    public void onButton4Pressed()
    {
        Debug.Log(controllers[currentPage*5+3].controllerName);
        currentController = controllers[currentPage*5 + 3];
        onControllerSelectedCommon(currentController);
    }

    public void onButton5Pressed()
    {
        Debug.Log(controllers[currentPage*5+4].controllerName);
        currentController = controllers[currentPage*5 + 4];
        onControllerSelectedCommon(currentController);
    }

    private void onControllerSelectedCommon(Controller controller)
    {
        // foreach (var device in neuroManager.Devices)
        //          {
        //     neuroManager.DisconnectDevice(device);
        // }
        DontDestroyOnLoad(GameObject.Find("NeuroManager"));
        SceneManager.LoadScene(14);
    }
    
}
