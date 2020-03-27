using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgePiece : MonoBehaviour
{

    [SerializeField] public Transform nextPosition;

    private void Start()
    {
    }

    public Transform getNextSpawnPos()
    {
        return nextPosition;
    }
}
