using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkRender : MonoBehaviour
{
    public Texture2D texture;
    Sprite sprite;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        texture = new Texture2D(Constants.chunkSize, Constants.chunkSize);
        texture.filterMode = FilterMode.Point;
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprite = Sprite.Create(texture, new Rect(0, 0, Constants.chunkSize, Constants.chunkSize), new Vector2(0.5f, 0.5f), Constants.chunkSize);
        spriteRenderer.sprite = sprite;

    }

    public void renderChunk(Constants.element[,] elements)
    {
		for (int y = 0; y < Constants.chunkSize; y++)
		{
			for (int x = 0; x < Constants.chunkSize; x++)
			{
                texture.SetPixel(x, y, Color.black);
                if (elements[x, y].type != Constants.eType.Empty) texture.SetPixel(x, y, Constants.eDataSet(elements[x, y].type).colour);
			}
		}
        texture.Apply();
	}
}
