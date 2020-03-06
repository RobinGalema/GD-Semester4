using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{

    public bool isActivated = false;
    public int objectsNeeded;

    private int objectsOnButton = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("--- A Player stepped on a button ---");
            // do some action
            objectsOnButton++;
            isActivated = checkActive();
            Debug.Log("---> Is the button active? : " + isActivated);

        }
        else if (collision.tag == "WeightedObject")
        {
            Debug.Log("--- A weighted object was placed on the button ---");
            // do some checks and actions
            objectsOnButton++;
            isActivated = checkActive();
            Debug.Log("---> Is the button active? : " + isActivated);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("--- A player stepped of the button ---");
            objectsOnButton--;
            isActivated = checkActive();
            Debug.Log("---> Is the button active? : " + isActivated);
        }
        else if (collision.tag == "WeightedObject")
        {
            Debug.Log("--- A weighted object was removed from the button ---");
            objectsOnButton--;
            isActivated = checkActive();
            Debug.Log("---> Is the button active? : " + isActivated);
        }
    }

    /// <summary>
    /// Function that checks if there are enough objects on a button to activate it
    /// </summary>
    /// <returns></returns>
    private bool checkActive()
    {
        if (objectsOnButton >= objectsNeeded)
        {
            return true;
        }
        else
            return false;
    }
}
