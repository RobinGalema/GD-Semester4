using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgePiece : MonoBehaviour
{

    [SerializeField] public Transform nextPosition;

    private void Awake()
    {

    }

    public Vector3 getNextSpawnPos()
    {
        return nextPosition.position;
    }
}
