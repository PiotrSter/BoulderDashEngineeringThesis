using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] tabOfMapObject = new GameObject[4];
    public Transform Map;
    public float mapYMax, mapXMax;
    public int borderGenerator = 0;
    /*void Awake()
    {
        BorderGenerate();
    }*/

    private void Update()
    {
        if (borderGenerator <= 3)
            BorderGenerate();
    }

    void BorderGenerate()
    {
        //int borderGenerator = 0;
        float yPosition, xPosition;
        switch (borderGenerator)
        {
            case 0:
                yPosition = -20f;
                do
                {
                    Instantiate(tabOfMapObject[0], new Vector3(-30, yPosition, 0), Quaternion.identity, Map);
                    yPosition += 0.6f;
                } while (yPosition <= 20f);
                mapYMax = yPosition;
                borderGenerator++;
                break;
            case 1:
                xPosition = -30f;
                do
                {
                    Instantiate(tabOfMapObject[0], new Vector3(xPosition, -20, 0), Quaternion.identity, Map);
                    xPosition += 0.6f;
                } while (xPosition <= 30f);
                mapXMax = xPosition;
                borderGenerator++;
                break;
            case 2:
                yPosition = -20f;
                do
                {
                    Instantiate(tabOfMapObject[0], new Vector3(mapXMax, yPosition, 0), Quaternion.identity, Map);
                    yPosition += 0.6f;
                } while (yPosition <= 20f);
                borderGenerator++;
                break;
            case 3:
                xPosition = -30f;
                do
                {
                    Instantiate(tabOfMapObject[0], new Vector3(xPosition, mapYMax, 0), Quaternion.identity, Map);
                    xPosition += 0.6f;
                } while (xPosition <= mapXMax);
                mapXMax = xPosition;
                borderGenerator++;
                break;
        }
    }
}



