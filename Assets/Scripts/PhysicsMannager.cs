using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhysicsMannager
{

	public static void SwapWith(ChunkData chunk, int X, int Y, int toSwapX, int toSwapY, Constants.element toSwap)
	{
		int i = 0, j = 0;

		if (X == toSwapX && Y == toSwapY) return;

		if ((X > -1 && X < Constants.chunkSize) && (Y > -1 && Y < Constants.chunkSize))
		{

		}
		else
		{
			if (toSwapX > Constants.chunkSize) i = 1;
			if (toSwapX < 0) i = -1;
			if (toSwapX > Constants.chunkSize) j = 1;
			if (toSwapX < 0) j = -1;
		}

	} 

	public static void UpdateSolid()
	{

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
