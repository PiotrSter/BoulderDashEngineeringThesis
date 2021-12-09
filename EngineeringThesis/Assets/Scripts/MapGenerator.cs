using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] tabOfMapObject = new GameObject[3];
    public GameObject boundar;
    public Transform Map;
    public int borderGenerator = 0;
    public Transform playerTransform;
    float xPosition, yPosition;
    GameManager gm;

    private void Awake()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        playerTransform.position = new Vector3(-9.36f, 4.84f, playerTransform.position.z);
        xPosition = -9.36f; 
        yPosition = 4.84f;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (borderGenerator <= 3)
            BorderGenerate();

        while (yPosition >= -4.84f)
        {
            TerrainGenerate();
        }
    }

    void BorderGenerate()
    {
        switch (borderGenerator)
        {
            case 0:
                GameObject leftWall;
                leftWall = Instantiate(boundar, new Vector3(-10f, 0, 0), Quaternion.identity, Map);
                leftWall.GetComponent<SpriteRenderer>().size = new Vector2(0.64f, 10.48f);
                leftWall.GetComponent<BoxCollider2D>().size = new Vector2(0.64f, 10.48f);
                borderGenerator++;
                break;
            case 1:
                GameObject upWall;
                upWall = Instantiate(boundar, new Vector3(0, 5.48f, 0), Quaternion.identity, Map);
                upWall.GetComponent<SpriteRenderer>().size = new Vector2(20.64f, 0.64f);
                upWall.GetComponent<BoxCollider2D>().size = new Vector2(20.64f, 0.64f);
                borderGenerator++;
                break;
            case 2:
                GameObject rightWall;
                rightWall = Instantiate(boundar, new Vector3(10f, 0, 0), Quaternion.identity, Map);
                rightWall.GetComponent<SpriteRenderer>().size = new Vector2(0.64f, 10.48f);
                rightWall.GetComponent<BoxCollider2D>().size = new Vector2(0.64f, 10.48f);
                borderGenerator++;
                break;
            case 3:
                GameObject downWall;
                downWall = Instantiate(boundar, new Vector3(0, -5.48f, 0), Quaternion.identity, Map);
                downWall.GetComponent<SpriteRenderer>().size = new Vector2(20.64f, 0.64f);
                downWall.GetComponent<BoxCollider2D>().size = new Vector2(20.64f, 0.64f);
                borderGenerator++;
                break;
        }
    }

    void TerrainGenerate()
    {
        int randomeObjectNumber;
       
        if (xPosition <= 9.36f)
        {
            if (gm.howManyCoin < 10)
                randomeObjectNumber = Random.Range(0, 3);
            else
                randomeObjectNumber = Random.Range(1, 3);
            GameObject randomeObject;
            randomeObject = Instantiate(tabOfMapObject[randomeObjectNumber], new Vector3(xPosition, yPosition, 0), Quaternion.identity, Map);
            if (randomeObject.CompareTag("Coin"))
                gm.howManyCoin++;

        }
        xPosition += 0.64f;
        if (xPosition > 9.36f)
        {
            yPosition -= 0.64f;
            xPosition = -9.36f;
        }
    }
}



