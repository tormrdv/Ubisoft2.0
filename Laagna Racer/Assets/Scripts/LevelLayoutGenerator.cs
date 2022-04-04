using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLayoutGenerator : MonoBehaviour
{
    public LevelChunkData[] levelChunkData;
    public LevelChunkData firstChunk;

    private LevelChunkData previousChunk;

    public Vector3 spawnOrigin;
    public Vector3 spawnPosition;
    public int chunksToSpawn;

    void onEnable()
    {
        TriggerExit.OnChunkExited += PickAndSpawnChunk;
    }
    private void OnDisable()
    {
        TriggerExit.OnChunkExited -= PickAndSpawnCunk;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            PickAndSpawnChunk;
        }
    }

    void Start()
    {
        previousChunk = firstChunk;

        for(int i = 0; i < chunksToSpawn; i++)
        {
            PickandSpawnChunk;
        }
    }
    LevelChunkData PickNextChunk()
    {
        List<LevelChunkData> allowedChunkList = new List<LevelChunkData>();
        LevelChunkData nextChunk = null;

        LevelChunkData.Direction nextRequiredDirection = LevelChunkData.Direction.North;

        //Checks what was the last exit direction of the Chunk
        switch (previousChunk.exitDirection)
        {
            case LevelChunkData.Direction.North:
                nextRequiredDirection = LevelChunkData.Direction.South;
                spawnPosition = spawnPosition + new Vector3(0f, 0, previousChunk.chunkSize.y);
                break;
            case LevelChunkData.Direction.east:
                nextRequiredDirection = LevelChunkData.Direction.West;
                spawnPosition = spawnPosition + new Vector3(previousChunk.chunkSize.x, 0, 0);
                break;
            // But why, if we aren't moving towards the South?
            case LevelChunkData.Direction.South:
                nextRequiredDirection = LevelChunkData.Direction.North;
                spawnPosition = spawnPostion + new Vector3(0, 0, -previousChunk.chunkSize.y);
                break;
            case LevelChunkData.Direction.West:
                nextRequiredDirection = LevelChunkData.Direction.East;
                spawnPosition = spawnPosition + new Vector3(-previousChunk.chunkSize.x, 0, 0);
                break;
            default:
                break;
        }
        //Adds all chunks that mach the required entry point to a list
        for(int i = 0; i < levelChunkData.Length; i++)
        {
            if(levelChunkData[i].entryDirection == nextRequiredDirection)
            {
                allowedChunkList.Add(levelChunkData[i]);
            }
        }
        //Randomly selects a chunk from the allowed list and returns it.
        nextChunk = allowedChunkList[Random.Range(0, allowedChunkList.Count)];
        return nextChunk;

    }

    void PickAndSpawnChunk()
    {
        LevelChunkData chunkToSpawn = PickNextChunk();

        GameObject objectFromChunk = chunksToSpawn.levelChunks[Random.Range(0, chunksToSpawn.levelChunks.Lenght)];
        previousChunk = chunksToSpawn;
        Instantiate(objectFromChunk, spawnPosition, Quaternion.identity);
    }

    public void UpdateSpawnOrigin(Vector3 originDelta)
    {
        spawnOrigin = spawnOrigin + originDelta;
    }
}
