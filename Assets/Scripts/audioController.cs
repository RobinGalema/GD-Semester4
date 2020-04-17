using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    public AudioSource source;

    [Header("Player sounds")]
    public AudioClip jumpSound;

    [Header("Lever Sounds")]
    public AudioClip leverOn;
    public AudioClip leverOff;

    [Header("Button Sounds")]
    public AudioClip buttonOn;
    public AudioClip buttonOff;

    [Header("Door Sounds")]
    public AudioClip doorOpen;
    public AudioClip doorClose;

    [Header("Box Sound")]
    public AudioClip boxDrag;

    public void playjumpsound()
    {
        source.clip = jumpSound;
        source.Play();
    }

    public void playLeverSound(bool willBeEnabled)
    {
        switch (willBeEnabled)
        {
            case true:
                {
                    source.clip = leverOn;
                    source.Play();
                    break;
                }
            case false:
                {
                    source.clip = leverOff;
                    source.Play();
                    break;
                }
        }
    }

    public void playButtonSound(bool willBeEnabled)
    {
        switch (willBeEnabled)
        {
            case true:
                {
                    source.clip = buttonOn;
                    source.Play();
                    break;
                }
            case false:
                {
                    source.clip = buttonOff;
                    source.Play();
                    break;
                }
        }
    }

    public void playDoorSound(bool willBeOpened)
    {
        switch (willBeOpened)
        {
            case true:
                {
                    source.clip = doorOpen;
                    source.Play();
                    break;
                }
            case false:
                {
                    source.clip = doorClose;
                    source.Play();
                    break;
                }
        }
    }

    public void playBoxDragSound()
    {
        source.clip = boxDrag;
        source.Play();
    }
}
