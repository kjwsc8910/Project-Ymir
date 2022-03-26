using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creates new chunks 

public class ChunkMannager : MonoBehaviour
{
    [SerializeField]
    GameObject chunkPrefab;

    public GameObject[,] chunks;
    public GameObject[] activeChunks;
    int numOfChunks; //Number of chunks loaded in

    public static bool run = false;

    void Start() 
    {
        //Variable set up
        chunks = new GameObject[Constants.worldSize, Constants.worldSize];
        activeChunks = new GameObject[Constants.worldSize * Constants.worldSize];
        numOfChunks = 0;

        //Physics Set Up
        PhysicsMannager.PhysicsSetUp();

        GenerateChunk(0, 0);
        GenerateChunk(1, 0);
        GenerateChunk(0, 1);

    }

    public void GenerateChunk(int x, int y) //Instanciates a new chunk at pos X, pos Y
	{
        GameObject chunk = Instantiate(chunkPrefab, new Vector3(x, y, 0), Quaternion.identity);

        chunk.GetComponent<ChunkData>().posX = x;
        chunk.GetComponent<ChunkData>().posY = y;

        x *= 2;
        y *= 2;

        if (x < 0) x = -1 - x;
        if (y < 0) y = -1 - y;

        chunks[x, y] = chunk;
        activeChunks[numOfChunks] = chunk;
        numOfChunks++; //Increments Pointer

    }

	private void RenderChunks()
	{
        //Cycle through chunks
		for (int i = 0; i < numOfChunks; i++)
		{
            GameObject chunk = activeChunks[i];
            chunk.GetComponent<ChunkRender>().renderChunk(chunk.GetComponent<ChunkData>().matrix);

        }
    }

    private void UpdateChunks()
	{
		//Cycle through chunks
		for (int i = 0; i < numOfChunks; i++)
		{
            ChunkData chunk = activeChunks[i].GetComponent<ChunkData>();
            Constants.element[,] matrix = chunk.GetComponent<ChunkData>().matrix;
            Constants.element[,] nMatrix = matrix;

			for (int y = 0; y < Constants.chunkSize; y++)
			{
				for (int x = 0; x < Constants.chunkSize; x++)
				{
                    //Run Physics
                    if (Constants.eDataSet(matrix[x, y].type).state == Constants.eState.Solid) PhysicsMannager.UpdateSolid(chunk, x, y);
				}
			}
		}

        RenderChunks();
	}

	private void FixedUpdate()
	{
        if(run == true)UpdateChunks();
	}

	IEnumerator DelayedRender(float t) //Temporary Delayed Render
	{
        yield return new WaitForSeconds(t);

        RenderChunks();

    }    IEnumerator DelayedUpdate(float t) //Temporary Delayed Render
	{
        yield return new WaitForSeconds(t);

        UpdateChunks();

    }

}