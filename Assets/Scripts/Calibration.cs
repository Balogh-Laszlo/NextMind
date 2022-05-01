using System.Collections;
using System.Collections.Generic;
using NextMind;
using NextMind.Calibration;
using NextMind.Devices;
using TMPro;
using UnityEngine;

public class Calibration : MonoBehaviour
{
    public CalibrationManager calibrationManager;
    private NeuroManager neuroManager;

    public GameObject neuroTags;

    public GameObject startButton;

    public TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
        neuroManager = GameObject.Find("NeuroManager").GetComponent<NeuroManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onStartClicked()
    {
        if (neuroManager.IsReady())
        {
            startButton.SetActive(false);
            neuroTags.SetActive(true);
            calibrationManager.StartCalibration();
        }
        else
        {
            Debug.Log("NeuroManager is not ready");
        }
    }

    public void onCalibrationEnded(Device device, CalibrationResults.CalibrationGrade grade)
    {
        score.text = grade.ToString();
    }
}
