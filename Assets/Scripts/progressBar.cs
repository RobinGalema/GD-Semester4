using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class progressBar : MonoBehaviour
{
    // Creating a new Unity Event for when the progress changes
    UnityEvent m_onProgressChange = new UnityEvent();

    public button connectedButton;
    public Image fill;

    private Slider fillBar;
    private decimal progress;
    private int lastObjectsOnButton;

    // Start is called before the first frame update
    void Start()
    {
        // Get the slider out of the UI and set the fill color to blue for now
        fillBar = GetComponent<Slider>();
        fill.color = Color.blue;

        // check if there is a button connected and if so store the amount of objects on the button in a variable
        if (connectedButton != null)
        {
            lastObjectsOnButton = connectedButton.objectsOnButton;
        }

        // Add a listener to the UnityEvent
        m_onProgressChange.AddListener(progressChanged);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the amount of objects on the button changed
        if (lastObjectsOnButton != connectedButton.objectsOnButton)
        {
            // Update the last amount of objects on the button and invoke the function attatched to the UnityEvent
            lastObjectsOnButton = connectedButton.objectsOnButton;
            m_onProgressChange.Invoke();
        }
    }

    /// <summary>
    /// Updates the progressbar to match the percentage of items that are on a button compared to the amount needed to activate them
    /// </summary>
    void progressChanged()
    {
        // debug
        Debug.Log("Progress changed, it is now: " + ((decimal)connectedButton.objectsOnButton / (decimal)connectedButton.objectsNeeded) * 100 + "%");

        // Calculate the progress percentage
        progress = (decimal)connectedButton.objectsOnButton / (decimal)connectedButton.objectsNeeded;
        // Update the bar value
        fillBar.value = (float)progress * 100;
        
        // Set the bar color to green when it is completely filled
        if (fillBar.value == 100)
        {
            fill.color = Color.green; 
        }
        else
        {
            fill.color = Color.blue;
        }
    }
}
