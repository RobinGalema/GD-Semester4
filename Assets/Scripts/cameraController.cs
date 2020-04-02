using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    // Start is called before the first frame update
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
    }

    public void ToggleCamera(int cameraIndex)
    {
        switch (cameraIndex)
        {
            case 0:
                {
                    if (!cam1.enabled)
                    {
                        cam1.enabled = true;
                        cam2.enabled = false;
                    }
                    break;
                }
            case 1:
                {
                    if (!cam2.enabled)
                    {
                        cam1.enabled = false;
                        cam2.enabled = true;
                    }
                    break;
                }
        }
    }
}
