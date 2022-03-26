using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhysicsMannager
{
	private static ChunkMannager chunkMannager;

	public static void PhysicsSetUp()
	{
		chunkMannager = GameObject.FindGameObjectWithTag("Mannager").GetComponent<ChunkMannager>();
	}	

	public static void SwapWith(ChunkData chunk, int X, int Y, Constants.element toSwap, int toSwapX, int toSwapY, int i, int j)
	{
		Constants.element[,] matrix = chunk.matrix;
		Constants.element element = matrix[X, Y];

		Debug.Log("shit");

		if (X == toSwapX && Y == toSwapY) return;

		if (chunkMannager.chunks[i, j] == null) return;

		ChunkData targetChunk = chunkMannager.chunks[i, j].GetComponent<ChunkData>();

		matrix[X, Y] = toSwap;
		targetChunk.matrix[toSwapX, toSwapY] = element;
	}

	public static void GetElement(ChunkData chunk, int X, int Y, int toSwapX, int toSwapY, out int i, out int j, out int targX, out int targY, out Constants.element element)
	{
		Constants.element[,] matrix = chunk.matrix;
		i = chunk.i;
		j = chunk.j;
		targX = toSwapX;
		targY = toSwapY;
		element = matrix[X, Y];

		if (X == toSwapX && Y == toSwapY) return;

		if ((toSwapX > -1) && (toSwapX < Constants.chunkSize) && (toSwapY > -1) && (toSwapY < Constants.chunkSize))
		{
			element = matrix[toSwapX, toSwapY];
			Debug.Log("insdie");
		}
		else
		{
			Debug.Log("outside");
			if (toSwapX > Constants.chunkSize - 1) { i += 2; toSwapX -= (Constants.chunkSize - 1); };
			if (toSwapX < 0) { i += -2; toSwapX += (Constants.chunkSize - 1); };
			if (toSwapY > Constants.chunkSize - 1) { j += 2; toSwapY -= (Constants.chunkSize - 1); };
			if (toSwapY < 0) { j += -2; toSwapY += (Constants.chunkSize - 1); };

			i *= 2;
			j *= 2;

			if (i < 0) i = -1 - i;
			if (j < 0) j = -1 - j;

			targX = toSwapX;
			targY = toSwapY;

			if (chunkMannager.chunks[i, j] == null) { element = new Constants.element(Constants.eType.OutOfBounds); return; };

			ChunkData targetChunk = chunkMannager.chunks[i, j].GetComponent<ChunkData>();

			element = targetChunk.matrix[toSwapX, toSwapY];
		}
	}

	public static void UpdateSolid(ChunkData chunk, int X, int Y)
	{
		int i = 0, j = 0, targX = X, targY = Y - 1;
		Constants.element element;
		GetElement(chunk, X, Y, X, Y - 1, out i, out j, out targX, out targY, out element);
		Debug.Log(element.type);
		if ((Constants.eDataSet(element.type).state != Constants.eState.Solid) && (Constants.eDataSet(element.type).state != Constants.eState.OutOfBounds)) SwapWith(chunk, X, Y, element, targX, targY, i, j);
	}

	public static void UpdateLiquid()
	{

	}

	public static void UpdateGass()
	{

	}

	public static void MoveDown(GameObject chunk, Constants.element[,] matrix, Constants.element[,] nMatrix, int x, int y, out Constants.element[,] oMatrix, out bool move)
	{
		oMatrix = nMatrix;
		move = false;

		if (y == 0) return;
		if (nMatrix[x, y - 1].type != Constants.eType.Empty) return;

		Constants.element eOne = matrix[x, y];
		nMatrix[x, y] = new Constants.element();
		nMatrix[x, y - 1] = eOne;

		oMatrix = nMatrix;
		move = true;
		return;
	}

	public static void MoveDiagonalDown(GameObject chunk, Constants.element[,] matrix, Constants.element[,] nMatrix, int x, int y, out Constants.element[,] oMatrix, out bool move)
	{
		oMatrix = nMatrix;
		bool l = true;
		bool r = true;
		move = false;

		if (y == 0) return;

		if ((x == 0) || (nMatrix[x - 1, y - 1].type != Constants.eType.Empty)) l = false;
		if ((x == Constants.chunkSize - 1) || (nMatrix[x + 1, y - 1].type != Constants.eType.Empty)) r = false;

		if (l == false && r == false) return;

		if ((l && r) == true)
		{
			bool rand = Random.Range(0f, 1f) > 0.5f;
			l = rand ? true  : false;
			r = rand ? false : true;
		}

		if(l == true)
		{
			Constants.element eOne = matrix[x, y];
			nMatrix[x, y] = new Constants.element();
			nMatrix[x - 1, y - 1] = eOne;
			move = true;
		}
		if(r == true)
		{
			Constants.element eOne = matrix[x, y];
			nMatrix[x, y] = new Constants.element();
			nMatrix[x + 1, y - 1] = eOne;

			move = true;
		}

		oMatrix = nMatrix;
		return;
	}

}
