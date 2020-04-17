using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    public AudioSource source;
    public AudioClip jumpSound;

    public void playjumpsound()
    {
        source.clip = jumpSound;
        source.Play();
    }
}
