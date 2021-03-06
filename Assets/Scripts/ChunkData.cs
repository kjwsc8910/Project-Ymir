using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ChunkData : MonoBehaviour
{
    public Constants.element[,] matrix;
    public int posX;
    public int posY;
    public int i;
    public int j;

    void Start()
    {

        matrix = new Constants.element[Constants.chunkSize, Constants.chunkSize];

        i = posX;
        j = posY;

        i *= 2;
        j *= 2;

        if (i < 0) i = -1 - i;
        if (j < 0) j = -1 - j;

        ChunkMannager.run = true;
    }

	private void Update()
	{

	}

    private void OnMouseDown()
    {

        Vector3 mousePos = Input.mousePosition; //Take mouse position in pixels
        mousePos.z += 10;
        mousePos.x = (mousePos.x) / Camera.main.GetComponent<PixelPerfectCamera>().pixelRatio; //Convert screen pixels into scaled world pixels
        mousePos.y = (mousePos.y) / Camera.main.GetComponent<PixelPerfectCamera>().pixelRatio;

        mousePos.x = mousePos.x - (Camera.main.WorldToScreenPoint(new Vector3(transform.position.x - 0.5f, 0, 0)).x / Camera.main.GetComponent<PixelPerfectCamera>().pixelRatio); //Subtract the world pixels 
        mousePos.y = mousePos.y - (Camera.main.WorldToScreenPoint(new Vector3(0, transform.position.y - 0.5f, 0)).y / Camera.main.GetComponent<PixelPerfectCamera>().pixelRatio); // To corner of chunk

        mousePos.x = Mathf.FloorToInt(mousePos.x); //Round down 
        mousePos.y = Mathf.FloorToInt(mousePos.y);

        matrix[(int)mousePos.x, (int)mousePos.y] = new Constants.element(Constants.eType.Sand); //Spawn Sand     

    }

}
