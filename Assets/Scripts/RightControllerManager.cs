using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RightControllerManager : MonoBehaviour
{
    SteamVR_TrackedController controller;
    public Image indicator;
    private Color originalColor;

    private ButtonHandler currentSelector = null;

    public LineRenderer lineRenderer;

    public ControllerScene cs;

    private float range = 100f;

    void Start()
    {
        controller = GetComponent<SteamVR_TrackedController>();
        if (controller == null)
        {
            controller = gameObject.AddComponent<SteamVR_TrackedController>();
        }
        controller.TriggerClicked += Fire;
        originalColor = indicator.color;
    }

    void Update()
    {
        if (cs.ButtonEnabled)
        {
            RaycastHit hitInfo;
            
            if (Physics.Raycast(transform.position, transform.forward, out hitInfo))
            {
                if (currentSelector != null)
                {
                    unhighlight();
                    currentSelector = null;
                    range = 100f;
                }
                currentSelector = hitInfo.collider.gameObject.GetComponent<ButtonHandler>();
                if (currentSelector != null)
                {
                    range = hitInfo.distance;
                    highlight();
                }
            }
            else
            {
                unhighlight();
                currentSelector = null;
                range = 100f;
            }
        }
        else
        {
            range = 0f;
        }

        lineRenderer.SetPosition(lineRenderer.numPositions - 1, Vector3.forward * range);
    }

    public void DrawLaser()
    {

        //DrawLine(transform.position, transform.forward * 100, Color.green);	
    }

    //This will cause the button to be triggered when the laser pointer hits it
    void Fire(object sender, ClickedEventArgs e)
    {
        if (currentSelector != null)
        {
            if (currentSelector.scene1)
            {
                SceneManager.LoadScene("Scene1");
            }
            else if (currentSelector.scene2)
            {
                SceneManager.LoadScene("Scene2");
            }
            else if (currentSelector.scene3)
            {
                SceneManager.LoadScene("Scene3");
            }
        }
        //Debug.Log("Laser Fired");
        //int layerMask = 1 << 8;
        //RaycastHit _hit;

        //if (Physics.Raycast(transform.position, transform.forward * 100, out _hit))
        //{
        //    GameObject button = _hit.collider.gameObject;  
        //        ButtonHandler buttonHandler = _hit.collider.gameObject.GetComponent<ButtonHandler>();

        //        if (buttonHandler.scene1)
        //        { 
        //            SceneManager.LoadScene("Scene1");
        //        }
        //        else if (buttonHandler.scene2)
        //        { 
        //            SceneManager.LoadScene("Scene2");
        //        }
        //        else if (buttonHandler.scene3)
        //        { 
        //            SceneManager.LoadScene("Scene3");
        //        }
        //}

    }

    public void highlight()
    {
        //indicator.color = Color.Lerp(originalColor, Color.red, 0.5f);
    }

    public void unhighlight()
    {
        //indicator.color = originalColor;
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
