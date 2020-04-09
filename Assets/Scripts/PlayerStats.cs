using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Vector2 spawnPos;
    public int deathCounter;

    public PlayerInfo playerInfo;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void setSpawnPos(Vector2 newPos)
    {
        spawnPos = newPos;
        playerInfo.spawnPos = spawnPos;
        Debug.Log("checkpoint changed, new spawning position = " + spawnPos);
    }

    public void setDeaths (int newDeathAmount)
    {
        deathCounter = newDeathAmount;
        playerInfo.deathCounter = deathCounter;
    }

    public bool doesSaveExist()
    {
        if (playerInfo.readFromDisk())
        {
            spawnPos = playerInfo.spawnPos;
            deathCounter = playerInfo.deathCounter;
            return true;
        }
        else
        {
            return false;
        }
    }
}
