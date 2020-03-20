using System.Collections;
using UnityEngine;

public class bridgeSpawner : MonoBehaviour
{
    public bridgePiece prototype;
    public int piecesToSpawn;

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
        if (buttonCheck.checkForStateChange() && buttonCheck.state && !hasSpawned)
        {
            hasSpawned = true;
            StartCoroutine(startSpawning());
        }
    }

    private void spawnNext(Vector3 nextSpawnPosition)
    {
        bridgePiece spawnedPiece = Instantiate(prototype, nextSpawnPosition, Quaternion.identity);
        _nextSpawnPosition = spawnedPiece.nextPosition;
    }

    IEnumerator startSpawning()
    {
        for (int i = 0; i < piecesToSpawn; i++)
        {
            yield return new WaitForSeconds(0.5f);
            spawnNext(_nextSpawnPosition);
        }
    }
}
