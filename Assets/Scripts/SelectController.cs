
using System.Collections.Generic;
using API;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// [RequireComponent(typeof(LoadScript))]
public class SelectController : MonoBehaviour
{
    //UI elements
    public GameObject nextPageMindButton;
    public GameObject prevPageButton;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;

    //Data objects(backend)
    private List<RemoteController> remoteControllers;
    private List<GameObject> buttons;
    public static RemoteController selectedRemoteController;
    private int currentPage = 0;
    void Start()
    {
        buttons = new List<GameObject>() {button1, button2, button3, button4, button5};
        StartCoroutine(APIHelper.Instance.GetRemoteControllers((response) =>
        {
            Debug.Log("Response:" + response.Code);
            if (response.Code == 200)
            {
                remoteControllers = response.RemoteControllers;
                Debug.Log("Remote controllers count " + remoteControllers.Count);
                showControllers();
            }
            else
            {
                Debug.Log(response.Message);
            }
        }));

    }
    private void showControllers()
    {
        currentPage = 0;
        assignControllersToButtons(currentPage);
        checkNavButtons();
    }

    private void assignControllersToButtons(int currentPage)
    {
        int buttonIndex = 0;
        for (int i = currentPage * 5; i < currentPage * 5 + 5; ++i)
        {
            if (remoteControllers.Count > i)
            {
                buttons[buttonIndex].SetActive(true);
                var text = buttons[buttonIndex].GetComponentInChildren<TMP_Text>();
                if (text != null)
                {
                    text.text = remoteControllers[i].Name;
                }
            }
            else
            {
                buttons[buttonIndex].SetActive(false);
            }

            buttonIndex++;
        }
    }

    private void checkNavButtons()
    {
        if (currentPage == 0)
        {
            prevPageButton.SetActive(false);
        }
        else
        {
            prevPageButton.SetActive(true);
        }

        if ((currentPage * 5 + 5) >= remoteControllers.Count)
        {
            nextPageMindButton.SetActive(false);
        }
        else
        {
            nextPageMindButton.SetActive(true);
        }
    }
    public void onBackPressed()
    {
        DontDestroyOnLoad(GameObject.Find("NeuroManager"));
        SceneManager.LoadScene(1);
        
    }

    public void nextPage()
    {
        currentPage++;
        assignControllersToButtons(currentPage);
        checkNavButtons();
    }

    public void prevPage()
    {
        currentPage -= 1;
        assignControllersToButtons(currentPage);
        checkNavButtons();
    }

    public void onButton1Pressed()
    {
        onControllerSelectedCommon(currentPage*5+0);
    }

    public void onButton2Pressed()
    {
        onControllerSelectedCommon(currentPage*5+1);
    }

    public void onButton3Pressed()
    {
        onControllerSelectedCommon(currentPage*5+2);
    }

    public void onButton4Pressed()
    {
        onControllerSelectedCommon(currentPage*5+3);
    }

    public void onButton5Pressed()
    {
        onControllerSelectedCommon(currentPage*5+4);
    }

    private void onControllerSelectedCommon(int index)
    {
        selectedRemoteController = remoteControllers[index];
        DontDestroyOnLoad(GameObject.Find("NeuroManager"));
        SceneManager.LoadScene(14);
    }
    
}
