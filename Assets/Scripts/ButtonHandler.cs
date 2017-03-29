using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler: MonoBehaviour {

	public bool scene1;
	public bool scene2;
	public bool scene3;

	public void OnCollisionEnter(Collision col) {
		Debug.Log("CollisionEnter");
	}

	public void OnTriggerEnter (Collider other) {
        Debug.Log("Button Handler Trigger Enter");
		if(other.tag == "VrController")
 		{
     if(scene1 == true)
     {
         SceneManager.LoadScene("Scene1"); //This will load the scene that is named "Floor One" change the scene name in the script
     }
     else if(scene2 == true)
     {
         SceneManager.LoadScene("Scene2"); // loads a scene called "Floor Two"
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
