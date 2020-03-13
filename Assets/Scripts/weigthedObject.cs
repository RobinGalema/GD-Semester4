using UnityEngine;

public class weigthedObject : MonoBehaviour
{
    [SerializeField] private bool playerInRange;
    public float objectWeight;

    private Rigidbody2D rb;
    private string interactionSuffix;
    private bool objectIsDraggable;
    private playerMovement playerController;
    private Transform playerGroundCheck;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        playerInRange = false;
        objectIsDraggable = false;
    }

    // Update is called once per frame
    void Update()
    {
        getPlayerInput();
    }

    private void FixedUpdate()
    {
        // Check player input to check if the object need to be dragged
        if (objectIsDraggable)
        {
            rb.velocity = new Vector2(playerController.horizontalMovement * playerController.movespeed, rb.velocity.y);
            if (playerController.horizontalMovement != 0f)
            {
                // Add a bit of velocity to the box in the movement direction to counter the higher friction on the gameobject
                if (playerController.horizontalMovement > 0)
                {
                    rb.velocity = rb.velocity + new Vector2(1f, 0f);
                }
                else if (playerController.horizontalMovement < 0)
                {
                    rb.velocity = rb.velocity + new Vector2(-1f, 0f);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player is in range of the object
        if (collision.tag == "Player")
        {
            Debug.Log("--- Player in box range [" + this.name + "] ---");
            playerInRange = true;
            // Get the information from the player that enters this object's range
            interactionSuffix = collision.GetComponent<playerMovement>().controllerSuffix;
            playerController = collision.GetComponent<playerMovement>();
            playerGroundCheck = collision.GetComponentInChildren<Transform>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the player leaves the interaction range
        if (collision.tag == "Player")
        {
            Debug.Log("--- Player leaving box range [" + this.name + "] ---");
            playerInRange = false;
        }
    }

    private void getPlayerInput()
    {
        // Check if the player is in range
        if (playerInRange)
        {
            // Check if the player isn't on top of the box
            if (playerGroundCheck.position.y <= transform.position.y)
            {
                // Check for button input of the in-range player
                if (Input.GetButtonDown("RB" + interactionSuffix))
                {
                    Debug.Log("The player wants to move the block around");
                    // Tag the object as draggable so it can be moved in FixedUpdate
                    objectIsDraggable = true;
                }

                if (Input.GetButtonUp("RB" + interactionSuffix))
                {
                    Debug.Log("The player wants to stop moving the block");
                    // Tag the object to immovable when the player releases the drag button
                    objectIsDraggable = false;
                }
            }
            else
            {
                // When the player is on top of the box it should not be able to be dragged
                playerInRange = false;
                objectIsDraggable = false;
            }
        }
        else
        {
            // Set checks to false when the plauyer leaves the range of the object so it stops following the player
            playerInRange = false;
            objectIsDraggable = false;
        }
    }
}
