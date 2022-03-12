using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using NextMind;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RemoteControl : MonoBehaviour
{
    public TMP_Text name;
    public Controller controller;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject prevPage;
    public GameObject nextPage;
    public NeuroManager neuroManager;

    private List<GameObject> buttons;
    private List<Control> controlsOnScreen;

    private int currentPage = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(neuroManager.Devices.Count);
        if (SelectController.currentController != null)
        {
            controller = SelectController.currentController;
            name.text = controller.controllerName;
            buttons = new List<GameObject>();
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            controlsOnScreen = new List<Control>();
            int temp = currentPage * 5;
            prevPage.SetActive(false);
            if (controller.numberOfPages <= 1)
            {
                nextPage.SetActive(false);
            }
            for (int i = temp; i < temp +5; i++)
            {
                if (i < controller.controls.Count)
                {
                    TMP_Text text = buttons[i].GetComponentInChildren<TMP_Text>();
                    if (text != null)
                    {
                        if (controller.controls[i] != null && controller.controls[i].ControlName != null)
                        {
                            text.text = controller.controls[i].ControlName;
                            controlsOnScreen.Add(controller.controls[i]);
                        }
                        else
                        {
                            buttons[i].SetActive(false);
                            controlsOnScreen.Add(null);
                        }
                        
                    }
                }
                else
                {
                    
                    buttons[i].SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onBackPressed()
    {
        // foreach (var device in neuroManager.Devices)
        // {
        //     neuroManager.DisconnectDevice(device);
        // }
        SceneManager.LoadScene(12);
    }

    public void button1Pressed()
    {
        string url = "https://maker.ifttt.com/trigger/" + controlsOnScreen[currentPage * 5].CustomEvent +
                     "/json/with/key/" + controller.IFTTTKey;
        Utils.ping(url);
    }
    public void button2Pressed()
    {
        string url = "https://maker.ifttt.com/trigger/" + controlsOnScreen[currentPage * 5+1].CustomEvent +
                     "/json/with/key/" + controller.IFTTTKey;
        Utils.ping(url);
    }
    public void button3Pressed()
    {
        string url = "https://maker.ifttt.com/trigger/" + controlsOnScreen[currentPage * 5+2].CustomEvent +
                     "/json/with/key/" + controller.IFTTTKey;
        Utils.ping(url);
    }
    public void button4Pressed()
    {
        string url = "https://maker.ifttt.com/trigger/" + controlsOnScreen[currentPage * 5+3].CustomEvent +
                     "/json/with/key/" + controller.IFTTTKey;
        Utils.ping(url);
    }
    public void button5Pressed()
    {
        string url = "https://maker.ifttt.com/trigger/" + controlsOnScreen[currentPage * 5+4].CustomEvent +
                     "/json/with/key/" + controller.IFTTTKey;
        Utils.ping(url);
    }
}
