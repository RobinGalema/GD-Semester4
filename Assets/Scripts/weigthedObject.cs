using UnityEngine;

public class weigthedObject : MonoBehaviour
{
    private bool playerInRange = false;
    public bool yeet;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("--- Player in box range [" + this.name + "] ---");
            playerInRange = true;
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

}
