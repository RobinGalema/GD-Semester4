using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    public button connectedButton;
    public lever connectedLever;

    private bool state;
    private bool lastState;
    private SpriteRenderer sprite;

    private void Start()
    {
        //sprite = GetComponent<SpriteRenderer>();
        setup();
    }

    private void Update()
    {
        checkForStateChange();
    }

    private void setup()
    {
        if (connectedButton != null)
        {
            // using button
            state = connectedButton.isActivated;
            lastState = state;
        }
        else if (connectedLever != null)
        {
            // using lever
            state = connectedLever.isActive;
            lastState = state;
        }

    }

    private void checkForStateChange()
    {
        if (connectedButton != null)
        {
            // using button
            state = connectedButton.isActivated;
            if (state != lastState)
            {
                Debug.Log("button state changed");
                //stateChanged(state);
            }
            lastState = state;

        }
        else if (connectedLever != null)
        {
            // using lever
            state = connectedLever.isActive;
            if (state != lastState)
            {
                //stateChanged(state);
            }
            lastState = state;

        }
    }

    private void stateChanged(bool Active)
    {
        if (Active)
        {
            // The button or lever is ON
            // do something
            //sprite.color = Color.green;
        }
        else
        {
            // The button or lever is OFF
            // do something
            //sprite.color = Color.red;
        }
    }
}

