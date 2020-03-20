using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxSpawner : MonoBehaviour
{
    public GameObject boxToSpawn;
    public Transform spawnPoint;

    private ButtonCheck button;
    private bool hasBoxInWorld;
    private GameObject spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<ButtonCheck>();
        hasBoxInWorld = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (button.state && !hasBoxInWorld)
        {
            Debug.Log("--- spawning box ---");
            spawnBox(boxToSpawn);
        }
        else if (button.checkForStateChange() && button.state && hasBoxInWorld)
        {
            Debug.Log("--- Deleting old box and spawning a new one ---");
            Destroy(spawnedObject);
            spawnBox(boxToSpawn);
        }
    }

    private void spawnBox(GameObject objectToSpawn)
    {
        Debug.Log("Spawning new box");
        spawnedObject = Instantiate(objectToSpawn, spawnPoint.transform.position, Quaternion.identity);
        hasBoxInWorld = true;
    }

}
