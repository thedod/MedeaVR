using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;

public class ClickableObject : MonoBehaviour
{
    private HighlightEffect highlightEffect;
    private bool wasClicked;

    void Start()
    {
        wasClicked = false;

        // Get the renderer and material of the object
        highlightEffect = GetComponent<HighlightEffect>();
        highlightEffect.enabled = true;
    }

    void Update()
    {
        if (!wasClicked)
        {
            // Check if the left mouse button was clicked
            if (Input.GetMouseButtonDown(0))
            {
                // Create a ray from the camera to the mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                // Store hit info in a RaycastHit variable
                RaycastHit hit;

                // Perform the raycast and check if it hits a collider
                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the clicked object has the same GameObject name
                    if (hit.transform.gameObject == gameObject)
                    {
                        // Call the function you want to trigger
                        OnObjectClicked();
                    }
                }
            }

        }

    }

    // Function that gets triggered when the object is clicked
    void OnObjectClicked()
    {
        Debug.Log(gameObject.name + " was clicked!");
        wasClicked = true;
        highlightEffect.enabled = false;

    }



}
