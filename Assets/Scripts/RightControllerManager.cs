using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RightControllerManager : MonoBehaviour {
    SteamVR_TrackedController controller; 

    void Start () {
        controller = GetComponent<SteamVR_TrackedController>();
        if (controller == null)
        {
            controller = gameObject.AddComponent<SteamVR_TrackedController>();
        }
        controller.TriggerClicked += new ClickedEventHandler(Fire);
    }

    public void DrawLaser()
    {
         DrawLine(transform.position, transform.forward * 100, Color.green);	
    } 

    //This will cause the button to be triggered when the laser pointer hits it
    void Fire(object sender, ClickedEventArgs e)
    { 
        Debug.Log("Laser Fired");
        int layerMask = 1 << 8;
        RaycastHit _hit;

        if (Physics.Raycast(transform.position, transform.forward * 100, out _hit))
        {
            GameObject button = _hit.collider.gameObject;
	        Debug.Log("Laser hit");
	        Debug.Log(button); 
                ButtonHandler buttonHandler = _hit.collider.gameObject.GetComponent<ButtonHandler>();
                 
                if (buttonHandler.scene1)
                { 
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
