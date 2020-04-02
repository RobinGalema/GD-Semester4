using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class chaseController : MonoBehaviour
{
    UnityEvent CameraOvertake = new UnityEvent();
    public Camera chaseCam;
    public cameraController camController;
    public float chaseSpeed = 0.1f;
    public Transform chaseEnd;

    private chaseCamera chaseCamController;
    private bool isChasing = false;
    private GameObject player;
    private bool hasOvertakenPlayer;
    private Vector3 chaseCameraStartPos;

    private void Start()
    {
        chaseCamController = chaseCam.GetComponent<chaseCamera>();
        chaseCameraStartPos = chaseCam.transform.position;
        CameraOvertake.AddListener(onCameraOvertake);
        hasOvertakenPlayer = chaseCamController.playerOvertaken;
    }

    // Update is called once per frame
    void Update()
    {   
        // Check if the player got overtaken by the camera, if so invoke the unityevent
        if (hasOvertakenPlayer != chaseCamController.playerOvertaken)
        {
            if (chaseCamController.playerOvertaken == true)
            {
                CameraOvertake.Invoke();
            }
            hasOvertakenPlayer = chaseCamController.playerOvertaken;
        }
    }

    private void FixedUpdate()
    {
        // Check if the chase is started
        if (isChasing == true)
        {
            // Move the camera to the right
            chaseCam.transform.position = chaseCam.transform.position + new Vector3(chaseSpeed, 0f, 0f);

            if (player != null)
            {
                Debug.Log("player referenced");
                // Check if the player has reached the end of the chase and end the chase if they have
                if (player.transform.position.x >= chaseEnd.position.x)
                {
                    Debug.Log("stopping chase");
                    isChasing = false;
                    
                    // Switch to the normal camera
                    camController.ToggleCamera(0);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.tag == "Player")
        {
                Debug.Log("the player triggered the chase camera, starting chase");
                player = collision.gameObject;

                // Set the spawnpoint of the player to the start of the chase;
                player.GetComponent<playerMovement>().spawnPos = transform.position;

                // Switch to the chase camera
                camController.ToggleCamera(1);
                //Start the chase
                startChase();
        }
    }

    private void startChase()
    {
        // Set the chase variable to true to start moving the camera in fixedUpdate
        isChasing = true;
        chaseCam.GetComponent<chaseCamera>().startedChase = true;

        // Disable the start collider when the chase is started
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void onCameraOvertake()
    {
        // Set the chase variable to false to stop moving the camera in fixedUpdate
        isChasing = false;
        // Reset the camera position to the start of the chase
        chaseCam.transform.position = chaseCameraStartPos;

        // Reset the player and restart the chase
        player.GetComponent<playerMovement>().resetPlayer();
        startChase();
    }
}
