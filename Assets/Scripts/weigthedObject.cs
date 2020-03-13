using UnityEngine;

public class weigthedObject : MonoBehaviour
{
    [SerializeField] private bool playerInRange;
    public float objectWeight;

    private Rigidbody2D rb;
    private string interactionSuffix;
    private bool objectIsDraggable;
    private Rigidbody2D playerRb;

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
        if (objectIsDraggable)
        {
            rb.velocity = playerRb.velocity;
            rb.velocity = rb.velocity + new Vector2(1f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("--- Player in box range [" + this.name + "] ---");
            playerInRange = true;
            interactionSuffix = collision.GetComponent<playerMovement>().controllerSuffix;
            playerRb = collision.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("--- Player leaving box range [" + this.name + "] ---");
            playerInRange = false;
        }
    }

    private void getPlayerInput()
    {
        if (playerInRange)
        {
            if (Input.GetButtonDown("LB" + interactionSuffix))
            {
                Debug.Log("The player wants to move the block around");
                objectIsDraggable = true;
            }

            if (Input.GetButtonUp("LB" + interactionSuffix))
            {
                Debug.Log("The player wants to stop moving the block");
                objectIsDraggable = false;
            }
        }
        else
        {
            playerInRange = false;
            objectIsDraggable = false;
        }
    }
}
