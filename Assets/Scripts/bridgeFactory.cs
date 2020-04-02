using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeFactory : MonoBehaviour
{
    public bridgePiece prototype;
    public int piecesToSpawn;
    public bool piecesDoDestroy;
    public float timeAlive;

    private List<bridgePiece> spawnedPieces = new List<bridgePiece>();
    private ButtonCheck buttonCheck;
    private bool hasSpawned;
    private Vector3 _nextSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        buttonCheck = GetComponent<ButtonCheck>();
        hasSpawned = false;
        _nextSpawnPosition = transform.position;
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

    private void spawnNext(Vector3 nextSpawnPosition)
    {
        bridgePiece spawnedPiece = Instantiate(prototype, nextSpawnPosition, Quaternion.identity);
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
            yield return new WaitForSeconds(timeAlive);
            destroyPieces();
        }

    }

    public void destroyPieces()
    {
        foreach (var piece in spawnedPieces)
        {
            Debug.Log("Destroying: " + piece.gameObject.GetInstanceID());
            Destroy(piece.gameObject);
        }
        spawnedPieces.Clear();
        _nextSpawnPosition = transform.position;
    }
}
