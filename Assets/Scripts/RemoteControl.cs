using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using API;
using DefaultNamespace;
using Models;
using NextMind;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class RemoteControl : MonoBehaviour
{
    //UI elements
    public TMP_Text name;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject prevPage;
    public GameObject nextPage;

    private List<GameObject> buttons;
    private int currentPageIndex = 0;
    private Page currentPage;
    
    // Start is called before the first frame update
    void Start()
    {
        buttons = new List<GameObject>();
        buttons.Add(button1);
        buttons.Add(button2);
        buttons.Add(button3);
        buttons.Add(button4);
        buttons.Add(button5);
        name.text = SelectController.selectedRemoteController.Name;
        //sort the pages by index
        SelectController.selectedRemoteController.Pages.Sort((page1, page2)=> page1.Index > page2.Index? 1 : 0);
        currentPage = SelectController.selectedRemoteController.Pages[0];
        Debug.Log(currentPage.Index);
        checkNavButtons();
        assignButtons();

    }
    

    private void assignButtons()
    {
        for (int i = 0; i < 5; ++i)
        {
            if (currentPage.Controls.Count > i)
            {
                buttons[i].SetActive(true);
                var text = buttons[i].GetComponentInChildren<TMP_Text>();
                text.text = currentPage.Controls[i].Name;
            }
            else
            {
                buttons[i].SetActive(false);
            }
            
        }
    }

    private void checkNavButtons()
    {
        if (currentPageIndex == 0)
        {
            prevPage.SetActive(false);
        }
        else
        {
            prevPage.SetActive(true);
        }

        if (currentPageIndex < SelectController.selectedRemoteController.Pages.Count-1)
        {
            nextPage.SetActive(true);
        }
        else
        {
            nextPage.SetActive(false);
        }
    }
    public void onNextPressed()
    {
        currentPageIndex++;
        currentPage = SelectController.selectedRemoteController.Pages[currentPageIndex];
        checkNavButtons();
        assignButtons();
    }

    public void onPrevPressed()
    {
        currentPageIndex--;
        currentPage = SelectController.selectedRemoteController.Pages[currentPageIndex];
        checkNavButtons();
        assignButtons();
    }
    
    public void onBackPressed()
    {
        DontDestroyOnLoad(GameObject.Find("NeuroManager"));
        SceneManager.LoadScene(13);
    }

    public void OnButtonPressed(int i)
    {
        StartCoroutine(APIHelper.Instance.Ping(currentPage.Controls[i].URl, currentPage.Controls[i].IFTTTKey.iftttKey,(result) =>
        {
            Debug.Log(result);
        }));
    }

}
