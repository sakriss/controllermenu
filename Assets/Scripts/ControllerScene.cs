using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerScene : MonoBehaviour
{

    SteamVR_TrackedObject obj;

    public GameObject buttonHolder;

    public bool ButtonEnabled;

    SteamVR_TrackedController controller;
    public RightControllerManager rightControllerManager;

    // Use this for initialization
    void Awake()
    {
        obj = GetComponent<SteamVR_TrackedObject>();
        buttonHolder.SetActive(false);
        ButtonEnabled = false;

    }
 
    void Update()
    {
        var device = SteamVR_Controller.Input((int)obj.index);
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            if (!ButtonEnabled)
            {
                buttonHolder.SetActive(true);
                ButtonEnabled = true;
            }
            else
            {
                buttonHolder.SetActive(false);
                ButtonEnabled = false;
            }
        }
        if (ButtonEnabled)
        {
            rightControllerManager.DrawLaser();
        }
    }  
}
