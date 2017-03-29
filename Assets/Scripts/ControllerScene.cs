using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerScene : MonoBehaviour {

	SteamVR_TrackedObject obj;

	public GameObject buttonHolder;

	public bool ButtonEnabled;


	// Use this for initialization
	void Awake () {
		obj = GetComponent<SteamVR_TrackedObject>();
		buttonHolder.SetActive(false);
		ButtonEnabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		var device = SteamVR_Controller.Input((int)obj.index);
		if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)){
			if(ButtonEnabled == false){
				buttonHolder.SetActive(true);
				ButtonEnabled = true;

			}else if (ButtonEnabled == true){
				buttonHolder.SetActive(false);
				ButtonEnabled = false;
			}
		}
	}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Button Handler Trigger Enter");

    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Button Handler Collision Enter");

    }
}
