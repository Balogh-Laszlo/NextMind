using System.Collections;
using System.Collections.Generic;
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

    private List<GameObject> buttons;
    // Start is called before the first frame update
    void Start()
    {
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
            for (int i = 0; i < 5; i++)
            {
                if (i < controller.controls.Count)
                {
                    TMP_Text text = buttons[i].GetComponentInChildren<TMP_Text>();
                    if (text != null)
                    {
                        if (controller.controls[i] != null && controller.controls[i].ControlName != null)
                        {
                            text.text = controller.controls[i].ControlName;
                        }
                        else
                        {
                            buttons[i].SetActive(false);
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
        SceneManager.LoadScene(12);
    }
}
