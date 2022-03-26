using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{

	public static int chunkSize = 64;

	public static int worldSize = 10;



	public static eData eDataSet(eType t) //Look Up Table
	{ 
		eData[] array = new eData[]
		{
			new eData(false, false, false, false ,false),	//Empty
			new eData(false, false, true, true, false),		//Sand
			new eData(false, false, true, true, true)		//Water
		};
		return array[(int)t];
	}


	public struct element
	{
		public Color colour;

		public int posX;
		public int posY;

		public int velX;
		public int velY;

		public eType type;

		public element(Color colour, int x, int y, int vx, int vy, eType type)
		{
			this.colour = colour;

			this.posX = x;
			this.posY = y;

			this.velX = vx;
			this.velY = vy;

			this.type = type;
		} //Constructor
	}

	public enum eType
	{
		Empty,
		Sand,
		water,
	}

	public class eData
	{
		public readonly bool up, dUp, down, dDown, side;

		public eData(bool up,  bool dUp, bool down, bool dDown, bool side)
		{
			this.up = up;
			this.dUp = dUp;
			this.down = down;			
			this.dDown = dDown;
			this.side = side;
		}
	}
}
