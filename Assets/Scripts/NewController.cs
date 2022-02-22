using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
[RequireComponent(typeof(SaveScript))]
public class NewController : MonoBehaviour
{
    // Start is called before the first frame update
    public string key = "";
    public string baseURL = "https://maker.ifttt.com/trigger/";
    public string endURL = "/json/with/key/";
    public int numberOfPages = 1;
    public List<Control> controls = new List<Control>();
    public string controllerName;

    public GameObject IFTTTkeyCanvas;
    public GameObject Controller;
    public GameObject NameYourController;

    
    public TMP_InputField ButtonName1;
    public TMP_InputField ButtonName2;
    public TMP_InputField ButtonName3;
    public TMP_InputField ButtonName4;
    public TMP_InputField ButtonName5;

    public TMP_InputField CustomEvent1;
    public TMP_InputField CustomEvent2;
    public TMP_InputField CustomEvent3;
    public TMP_InputField CustomEvent4;
    public TMP_InputField CustomEvent5;

    public TMP_InputField ControllerName;

    private List<TMP_InputField> buttonNames = new List<TMP_InputField>();
    private List<TMP_InputField> customEvents = new List<TMP_InputField>();

    public SaveScript saveScript;
    void Start()
    {
        buttonNames.Add(ButtonName1);
        buttonNames.Add(ButtonName2);
        buttonNames.Add(ButtonName3);
        buttonNames.Add(ButtonName4);
        buttonNames.Add(ButtonName5);
        
        customEvents.Add(CustomEvent1);
        customEvents.Add(CustomEvent2);
        customEvents.Add(CustomEvent3);
        customEvents.Add(CustomEvent4);
        customEvents.Add(CustomEvent5);

        saveScript = GetComponent<SaveScript>();
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

    public void onNewPagePressed()
    {
        numberOfPages++;
        saveButtonsData();
        clearFields();
    }

    public void onSetupNextPressed()
    {
        saveButtonsData();
        Controller.SetActive(false);
        NameYourController.SetActive(true);
        
    }

    private void saveButtonsData()
    {
        for (int i = 0; i < 5; ++i)
        {
            if (buttonNames[i].text.Length > 0 && customEvents[i].text.Length > 0)
            {
                Debug.Log(buttonNames[i].text);
                controls.Add(new Control(buttonNames[i].text,customEvents[i].text));
            }
            else
            {
                controls.Add(null);
            }
            
        }
    }

    private void clearFields()
    {
        for (int i = 0; i < 5; i++)
        {
            buttonNames[i].text = "";
            customEvents[i].text = "";
        }
    }

    public void onSavePressed()
    {
        if (ControllerName.text.Length >= 1)
        {
            controllerName = ControllerName.text;
            saveScript.SaveData();
            SceneManager.LoadScene(0);
            
        }
    }
    
}
