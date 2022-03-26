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
			new eData(eState.Empty, Color.black),	//Empty
			new eData(eState.Solid, Color.yellow),	//Sand
			new eData(eState.Liquid, Color.blue)	//Water
		};
		return array[(int)t];
	}


	public struct element
	{
		public eType type;

		public element(eType type) //Constructor
		{
			this.type = type;
		} 
	}

	public enum eType
	{
		Empty,
		Sand,
		water,
	}

	public enum eState
	{
		Empty,
		Solid,
		Liquid,
		Gass,
	}

	public class eData
	{
		public readonly eState state;
		public readonly Color colour;

		public eData(eState state, Color colour)
		{
			this.state = state;
			this.colour = colour;
		}
	}
}
