using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class progressBar : MonoBehaviour
{

    UnityEvent m_onProgressChange = new UnityEvent();

    public button connectedButton;
    public Image fill;

    private Slider fillBar;
    private decimal progress;
    private int lastObjectsOnButton;

    // Start is called before the first frame update
    void Start()
    {
        fillBar = GetComponent<Slider>();
        fill.color = Color.blue;

        if (connectedButton != null)
        {
            lastObjectsOnButton = connectedButton.objectsOnButton;
        }

        m_onProgressChange.AddListener(progressChanged);
    }

    // Update is called once per frame
    void Update()
    {
        if (lastObjectsOnButton != connectedButton.objectsOnButton)
        {
            lastObjectsOnButton = connectedButton.objectsOnButton;
            m_onProgressChange.Invoke();
        }
    }

    void progressChanged()
    {
        Debug.Log("Progress changed, it is now: " + ((decimal)connectedButton.objectsOnButton / (decimal)connectedButton.objectsNeeded) * 100 + "%");
        progress = (decimal)connectedButton.objectsOnButton / (decimal)connectedButton.objectsNeeded;
        fillBar.value = (float)progress * 100;
        
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
