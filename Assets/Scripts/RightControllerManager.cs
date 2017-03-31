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
                    //unhighlight();
                    currentSelector = null;
                    range = 100f;
                }
                currentSelector = hitInfo.collider.gameObject.GetComponent<ButtonHandler>();
                if (currentSelector != null)
                {
                    range = hitInfo.distance;
                    //highlight();
                }
            }
            else
            {
                //unhighlight();
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
    }
}
