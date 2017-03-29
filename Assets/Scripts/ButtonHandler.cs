using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler: MonoBehaviour {

	public bool scene1;
	public bool scene2;
	public bool scene3;

	public void OnTriggerEnter (Collider other) {
        Debug.Log("Button Handler Trigger Enter");
		if(other.tag == "VrController")
 		{
     if(scene1 == true)
     {
         SceneManager.LoadScene("Scene1"); //This will load the scene that is named "Scene1"
     }
     else if(scene2 == true)
     {
         SceneManager.LoadScene("Scene2"); // loads a scene called "Scene2"
     }
     else if(scene3 == true)
     {
         SceneManager.LoadScene("Scene3");
     }
     else
     {
         Debug.Log("Multiple bools were enabled on one object");
     }
  }
 }

}
