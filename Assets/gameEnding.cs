using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class gameEnding : MonoBehaviour
{
    public float videoDuration;

    public PlayerInfo player1Info;
    public PlayerInfo player2Info;
    public GameObject finaleText;

    private bool canSkip = false;
    private VideoPlayer vidPlayer;

    // Start is called before the first frame update
    void Start()
    {
        vidPlayer = GetComponent<VideoPlayer>();
        finaleText.SetActive(false);
        StartCoroutine(waitForVideo());
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            if (canSkip)
            {
                goToTitle();
            }
        }
    }

    IEnumerator waitForVideo()
    {
        yield return new WaitForSeconds(videoDuration);
        canSkip = true;
        vidPlayer.enabled = false;
        finaleText.SetActive(true);
    }

    private void goToTitle()
    {
        player1Info.spawnPos = Vector2.zero;
        player2Info.spawnPos = new Vector2(-5.5f, -5.5f);
        player1Info.StoreToDisk();
        player2Info.StoreToDisk();

        SceneManager.LoadScene("StartMenu");
    }
}
