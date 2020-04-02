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
        if (isChasing == true)
        {
            chaseCam.transform.position = chaseCam.transform.position + new Vector3(chaseSpeed, 0f, 0f);

            if (player != null)
            {
                Debug.Log("player referenced");
                if (player.transform.position.x >= chaseEnd.position.x)
                {
                    Debug.Log("stopping chase");
                    isChasing = false;
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
        isChasing = true;
        chaseCam.GetComponent<chaseCamera>().startedChase = true;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void onCameraOvertake()
    {
        isChasing = false;
        chaseCam.transform.position = chaseCameraStartPos;
        Debug.Log(chaseCameraStartPos);
        player.GetComponent<playerMovement>().resetPlayer();
        startChase();
    }
}
