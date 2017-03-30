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

    // Update is called once per frame
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

    //Hopfully this sets up the controller to fire a laser pointer
    void Start()
    {

    }

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.01f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.01f, 0.01f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }

}
