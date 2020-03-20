using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgePiece : MonoBehaviour
{
    [HideInInspector]public Vector3 nextPosition;

    private void Awake()
    {
        nextPosition = transform.position + new Vector3(2, 0, 0);
    }
}
