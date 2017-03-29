using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class ControllerScene : MonoBehaviour {

	SteamVR_TrackedObject obj;

	public GameObject buttonHolder;

	public bool ButtonEnabled;

	SteamVR_TrackedController controller;

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

	//Hopfully this sets up the controller to fire a laser pointer
	void Start () {
    controller = GetComponent<SteamVR_TrackedController>();
    if (controller == null)
    	{
        controller = gameObject.AddComponent<SteamVR_TrackedController>();
    	}
    	controller.TriggerClicked += new ClickedEventHandler(Fire);
	}

	//Hopefully this will cause the button to be triggered when the laser pointer hits it
 void Fire(object sender, ClickedEventArgs e)
 {
   Debug.Log("Laser Fired");
   int layerMask = 1 << 8;
   RaycastHit _hit;

   if (Physics.Raycast(transform.position, transform.forward * 10, out _hit, 10.0f, layerMask))
     {

		 GameObject button = _hit.collider.gameObject;
		 if(button.tag == "VrController")
		 {
     		ButtonHandler buttonHandler = _hit.collider.gameObject.GetComponent<ButtonHandler>();
     		if(buttonHandler.scene1)
			 {
				SceneManager.LoadScene("Scene1");
	 		}
	 		else if (buttonHandler.scene2)
			 {
				SceneManager.LoadScene("Scene2");
	 		}
	 		else if(buttonHandler.scene3)
			 {
				SceneManager.LoadScene("Scene3");
	 		}
     }
    
  }
 	
}
}
