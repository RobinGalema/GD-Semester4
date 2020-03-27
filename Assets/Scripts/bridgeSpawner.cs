using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeSpawner : MonoBehaviour
{
    public bridgePiece prototype;
    public int piecesToSpawn;
    public bool piecesDoDestroy;
    public float timeAlive;

    private List<bridgePiece> spawnedPieces = new List<bridgePiece>();
    private ButtonCheck buttonCheck;
    private bool hasSpawned;
    private Transform _nextSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        buttonCheck = GetComponent<ButtonCheck>();
        hasSpawned = false;
        _nextSpawnPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (buttonCheck.checkForStateChange())
        {
            Debug.Log("state changed");
            if (buttonCheck.state && !hasSpawned)
            {
                hasSpawned = true;
                Debug.Log("spawning");
                StartCoroutine(startSpawning());
            }
            else if (buttonCheck.state && hasSpawned && spawnedPieces.Count == 0)
            {
                Debug.Log("list is empty");
                StartCoroutine(startSpawning());
            }
        }
    }

    private void spawnNext(Transform nextSpawnPosition)
    {
        bridgePiece spawnedPiece = Instantiate(prototype, nextSpawnPosition);
        _nextSpawnPosition = spawnedPiece.getNextSpawnPos();
        spawnedPieces.Add(spawnedPiece);
    }

    IEnumerator startSpawning()
    {
        for (int i = 0; i < piecesToSpawn; i++)
        {
            spawnNext(_nextSpawnPosition);
            yield return new WaitForSeconds(0.5f);    
        }
        if (piecesDoDestroy)
        {
            StartCoroutine(destroyPieces());
        }
        
    }

    IEnumerator destroyPieces()
    {

        /*
        for (int i = spawnedPieces.Count; i-- > 0; )
        {
            yield return new WaitForSeconds(timeAlive);
            Debug.Log("Destroying: " + spawnedPieces[i].gameObject.GetInstanceID());
            Destroy(spawnedPieces[i].gameObject);
        }
        */

        for (int i = 0; i < spawnedPieces.ToArray().Length; i++)
        {
            yield return new WaitForSeconds(timeAlive);
            if (spawnedPieces[i] != null)
            {
                Debug.Log("Destroying: " + spawnedPieces[i].gameObject.GetInstanceID());
                Destroy(spawnedPieces[i].gameObject);
                spawnedPieces.Remove(spawnedPieces[i]);
            }
        }


        /*
        foreach (var piece in spawnedPieces)
        {
            yield return new WaitForSeconds(timeAlive);
            Debug.Log("Destroying: " + piece.gameObject.GetInstanceID());
            Destroy(piece.gameObject);
        }
        */
        spawnedPieces.Clear();
        _nextSpawnPosition = transform;
    }
}
