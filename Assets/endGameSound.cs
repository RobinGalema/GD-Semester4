using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip completionSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playCompletionSound();
        }
    }
    public void playCompletionSound()
    {
        source.clip = completionSound;
        source.Play();
    }
}
