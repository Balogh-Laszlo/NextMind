using System.Collections.Generic;
using API;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

public class NewController : MonoBehaviour
{
    //UI
    public TMP_InputField controllerName;
    public TMP_Text errorField;
    public GameObject addButtonsObject;
    private List<GameObject> addButtons;
    public GameObject addButton1;
    public GameObject addButton2;
    public GameObject addButton3;
    public GameObject addButton4;
    public GameObject addButton5;

    private List<GameObject> addControlComponents;
    public GameObject addControlComponent1;
    public GameObject addControlComponent2;
    public GameObject addControlComponent3;
    public GameObject addControlComponent4;
    public GameObject addControlComponent5;

    private List<GameObject> addNewControl;
    public GameObject addNewControl1;
    public GameObject addNewControl2;
    public GameObject addNewControl3;
    public GameObject addNewControl4;
    public GameObject addNewControl5;

    private IAPIHelper api;
    private List<Key> iftttKeys;
    private List<ControlToClient> controls;
    private List<ControlData> controlsData = new List<ControlData>();
    private List<TMP_Dropdown.OptionData> dropdownOptions = new List<TMP_Dropdown.OptionData>();
    private List<TMP_Dropdown.OptionData> iftttOptions = new List<TMP_Dropdown.OptionData>();
    
    //request values
    private List<PageData> pages = new List<PageData>();
    private PageData currentPage;
    private int currentPageIndex = -1;
    private AddControllerRequest request = new AddControllerRequest();
    void Start()
    {
        api = APIHelper.Instance;
        AddPage();
        addButtons = new List<GameObject>
        {
            addButton1,
            addButton2,
            addButton3,
            addButton4,
            addButton5
        };
        addControlComponents = new List<GameObject>()
        {
            addControlComponent1,
            addControlComponent2,
            addControlComponent3,
            addControlComponent4,
            addControlComponent5
        };
        addNewControl = new List<GameObject>()
        {
            addNewControl1,
            addNewControl2,
            addNewControl3,
            addNewControl4,
            addNewControl5,
        };
        if (!GetKeys())
        {
            iftttKeys = new List<Key>();
        }
        if (!GetControls())
        {
            controls = new List<ControlToClient>();
        }

       
    }

    private void GetControlsData()
    {
        foreach (var control in controls)
        {
            controlsData.Add(new ControlData()
            {
                ControlId = control.Id,
                ControlName = control.Name,
                IFTTTKey = control.IFTTTKey.iftttKey,
                IFTTTKeyId = control.IFTTTKey.Id,
                URl = control.URl
            });
        }
    }
    private void SetOptionsControl()
    {
        foreach (var control in controls)
        {
            dropdownOptions.Add(new TMP_Dropdown.OptionData(control.Name));
        }
        foreach (var comp in addControlComponents)
        {
            
            var dropdown = comp.GetComponentInChildren<TMP_Dropdown>();
            

            dropdown.options = new List<TMP_Dropdown.OptionData>();
            dropdown.options = dropdownOptions;
        }
    }

    private bool GetKeys()
    {
        var b = false;
        StartCoroutine(api.GetKeys(new GetKeysRequest() {Token = api.Token}, (response) =>
        {
            if (response != null)
            {
                if (response.Code == 200)
                {
                    iftttKeys = response.Keys;
                    MakeIftttDropdownOptions();
                    SetKeys();
                    b = true;
                }
                else
                {
                    errorField.text = response.Message;
                    errorField.alpha = 1;
                    StartCoroutine(Animations.FadeTextToZeroAlpha(3f, errorField));
                }
            }
            else
            {
                errorField.text = "Something went wrong. Try again later!";
                errorField.alpha = 1;
                StartCoroutine(Animations.FadeTextToZeroAlpha(3f, errorField));
            }
        }));
        return b;
    }

    private void MakeIftttDropdownOptions()
    {
        foreach (var opt in iftttKeys)
        {
            iftttOptions.Add(new TMP_Dropdown.OptionData(opt.iftttKey));
        }
    }
    private void SetKeys()
    {
        
        foreach (var comp in addNewControl)
        {
            var dropdown = comp.GetComponentInChildren<TMP_Dropdown>();
            dropdown.options = iftttOptions;
        }
    }

    private bool GetControls()
    {
        var b = false;
        StartCoroutine(api.GetControls(api.Token, (response) =>
        {
            if (response != null)
            {
                if (response.Code == 200)
                {
                    controls = response.controls;
                    Debug.Log("controls length:" + controls.Count);
                    SetOptionsControl();
                    GetControlsData();
                    b = true;
                }
                else
                {
                    errorField.text = response.Message;
                    errorField.alpha = 1;
                    StartCoroutine(Animations.FadeTextToZeroAlpha(3f, errorField));
                }
            }
            else
            {
                errorField.text = "Something went wrong. Try again later!";
                errorField.alpha = 1;
                StartCoroutine(Animations.FadeTextToZeroAlpha(3f, errorField));
            }
        }));
        return b;
    }

    public void OnClick(int i)
    {
        addButtons[i].SetActive(false);
        addControlComponents[i].SetActive(true);
        if (i + 1 != 5)
        {
            addButtons[i+1].SetActive(true);
        }

    }

    public void OnAddNewControlClicked(int i)
    {
        addControlComponents[i].SetActive(false);
        addNewControl[i].SetActive(true);
    }

    public void OnSaveComponentClicked(int i)
    {
        var value = addControlComponents[i].GetComponentInChildren<TMP_Dropdown>().value;
        Debug.Log("dropdown value:" + value);
        addControlComponents[i].SetActive(false);
        currentPage.Controls.Add(controlsData[value]);
    }

    public void OnSaveControlClicked(int i)
    {
        var components =addNewControl[i].GetComponentsInChildren<TMP_InputField>();
        var controlData = new ControlData();
        foreach (var comp in components)
        {
            if (comp.name == "DisplayName")
            {
                controlData.ControlName = comp.text;
            }
            if (comp.name == "WebhooksName")
            {
                controlData.URl = comp.text;
                
            }

            if (comp.name == "IftttKey" && comp.text.Length > 1)
            {
                controlData.IFTTTKey = comp.text;
                controlData.IFTTTKeyId = 0;
                // iftttOptions.Add(new TMP_Dropdown.OptionData(comp.text));
                // SetKeys();
            }
            else
            {
                controlData.IFTTTKeyId = iftttKeys[addNewControl[i].GetComponentInChildren<TMP_Dropdown>().value].Id;
            }
            comp.text = "";
            controlData.ControlId = 0;
        }
        controlsData.Insert(0,controlData);
        Debug.Log("controlsData length after save:" + controlsData.Count);
        ReassignOptions();
        addControlComponents[i].SetActive(true);
        addNewControl[i].SetActive(false);
    }

    private void AddPage()
    {
        currentPage = new PageData();
        currentPageIndex++;
        currentPage.Index = currentPageIndex;
    }

    private void ReassignOptions()
    {
        foreach (var comp in addControlComponents)
        {
            dropdownOptions = new List<TMP_Dropdown.OptionData>();
            var dropdown = comp.GetComponentInChildren<TMP_Dropdown>();
            foreach (var control in controlsData)
            {
                dropdownOptions.Add(new TMP_Dropdown.OptionData(control.ControlName));
            }

            dropdown.options = new List<TMP_Dropdown.OptionData>();
            dropdown.options = dropdownOptions;
        }
    }

    public void OnNewPageClicked()
    {
        request.Pages.Add(currentPage);
        AddPage();
        ResetUI();
    }

    private void ResetUI()
    {
        foreach (var comp in addButtons)
        {
            comp.SetActive(false);
        }

        foreach (var comp in addControlComponents)
        {
            comp.SetActive(false);
        }

        foreach (var comp in addNewControl)
        {
            comp.SetActive(false);
        }
        addButtons[0].SetActive(true);
    }

    public void SaveController()
    {
        request.Pages.Add(currentPage);
        if (controllerName.text.Length > 1)
        {
            request.ControllerName = controllerName.text;
            request.Token = api.Token;
            StartCoroutine(api.AddController(request, (response) =>
            {
                if (response.Code == 200)
                {
                    DontDestroyOnLoad(GameObject.Find("NeuroManager"));
                    SceneManager.LoadScene(1);
                }
                else
                {
                    Debug.Log(response.Code + " " + response.Message);
                }
                
            }));
        }
    }
}
