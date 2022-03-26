using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhysicsMannager
{

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

	public static void MoveUp(GameObject chunk, Constants.element[,] matrix, Constants.element[,] nMatrix, int x, int y, out Constants.element[,] oMatrix, out bool move)
	{
		oMatrix = nMatrix;
		move = false;

		oMatrix = nMatrix;
		return;
	}

	public static void MoveDiagonalyUp(GameObject chunk, Constants.element[,] matrix, Constants.element[,] nMatrix, int x, int y, out Constants.element[,] oMatrix, out bool move)
	{
		oMatrix = nMatrix;
		move = false;

		oMatrix = nMatrix;
		return;
	}

	public static void MoveSide(GameObject chunk, Constants.element[,] matrix, Constants.element[,] nMatrix, int x, int y, out Constants.element[,] oMatrix, out bool move)
	{
		oMatrix = nMatrix;
		move = false;

		oMatrix = nMatrix;
		return;
	}
}
