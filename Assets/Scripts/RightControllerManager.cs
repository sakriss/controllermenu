using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RightControllerManager : MonoBehaviour {
    SteamVR_TrackedController controller;
    // Use this for initialization
    void Start () {
        controller = GetComponent<SteamVR_TrackedController>();
        if (controller == null)
        {
            controller = gameObject.AddComponent<SteamVR_TrackedController>();
        }
        controller.TriggerClicked += new ClickedEventHandler(Fire);
    }
	
	
// Update is called once per frame
	
void Update () 
{

	DrawLine(transform.position, transform.forward * 100, Color.green);	
	
}

    //Hopefully this will cause the button to be triggered when the laser pointer hits it
    void Fire(object sender, ClickedEventArgs e)
    {
        //DrawLine(transform.position, transform.forward * 100, Color.red);
        Debug.Log("Laser Fired");
        int layerMask = 1 << 8;
        RaycastHit _hit;

        if (Physics.Raycast(transform.position, transform.forward * 100, out _hit))
        {
            GameObject button = _hit.collider.gameObject;
	    Debug.Log("Laser hit");
	    Debug.Log(button);
            //if (other.tag == "VrController")
            //{
                ButtonHandler buttonHandler = _hit.collider.gameObject.GetComponent<ButtonHandler>();
                Debug.Log("Inside button handler");
                if (buttonHandler.scene1)
                {
                    Debug.Log("Should load scene 1 now");
                    SceneManager.LoadScene("Scene1");
                }
                else if (buttonHandler.scene2)
                {
                    SceneManager.LoadScene("Scene2");
                }
                else if (buttonHandler.scene3)
                {
                    SceneManager.LoadScene("Scene3");
                }
            //}

        }

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
