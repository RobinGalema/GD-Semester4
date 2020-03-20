using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectInteraction : MonoBehaviour
{
    [SerializeField] private string controllerSuffix;
    private playerMovement playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
