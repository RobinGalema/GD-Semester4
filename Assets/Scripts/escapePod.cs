using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class escapePod : MonoBehaviour
{
    public GameObject uiElement;
    public PlayerInfo player1Info;
    public PlayerInfo player2Info;
    public string sceneToLoad;

    private bool playerInRange = false;
    private string playerSuffix;
    private List<GameObject> playersInRange = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        uiElement.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerSuffix = collision.gameObject.GetComponent<playerMovement>().controllerSuffix;
            playerInRange = true;
            playersInRange.Add(collision.gameObject);
            Debug.Log(playersInRange.Count);

            if (playersInRange.Count == 4)
            {
                uiElement.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            playerInRange = false;
            playersInRange.Remove(collision.gameObject);
            
            if (playersInRange.Count < 4)
            {
                uiElement.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {   
            if (Input.GetButtonDown("X"+playerSuffix))
            {
                Debug.Log("player wants to leave");
                if (playersInRange.Count == 4)
                {
                    LoadNextLevel(sceneToLoad);
                }  
            }
        }
    }

    private void LoadNextLevel(string sceneName)
    {
        player1Info.spawnPos = Vector2.zero;
        player2Info.spawnPos = Vector2.zero;
        player1Info.StoreToDisk();
        player2Info.StoreToDisk();

        SceneManager.LoadScene(sceneName);
    }
}
