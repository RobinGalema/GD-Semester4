using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    public button connectedButton;

    private SpriteRenderer sprite;
    private bool buttonState;
    private bool lastButtonState;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        buttonState = connectedButton.isActivated;
        setColor(buttonState);
        lastButtonState = buttonState;
    }

    private void Update()
    {
        buttonState = connectedButton.isActivated;
        if (buttonState != lastButtonState)
        {
            setColor(buttonState);
            lastButtonState = buttonState;
            Debug.Log("changing color");
        }

    }

    private void setColor(bool buttonActive)
    {
        if (buttonActive == false)
        {
            sprite.color = Color.red;
        }
        else if (buttonActive)
        {
            sprite.color = Color.green;
        }
        
    }
}

