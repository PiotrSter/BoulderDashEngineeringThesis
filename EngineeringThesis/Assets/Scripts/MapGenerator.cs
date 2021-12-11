using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] mapObjects = new GameObject[3];
    public GameObject borderPrefab;
    public Transform Map;
    public Transform playerTransform;
    public int sizeX = 30;
    public int sizeY = 16;
    public float width = .64f;
    GameManager gm;

    private void Awake()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        Vector2 playerSpriteSize = playerTransform.GetComponent<SpriteRenderer>().size;
        playerTransform.position = new Vector3(-(sizeX / 2 * width) + playerSpriteSize.x / 2, sizeY / 2 * width - playerSpriteSize.y / 2, playerTransform.position.z);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        BorderGenerate();
        TerrainGenerate();
    }

    private void Update()
    {

    }

    void BorderGenerate()
    {
        float borderWidth = width * (sizeX + 2);
        float borderHeight = width * sizeY;

        GameObject border = Instantiate(borderPrefab, new Vector2(0.0f, sizeY / 2 * width + width / 2), Quaternion.identity, Map);
        border.GetComponent<SpriteRenderer>().size = new Vector2(borderWidth, width);
        border.GetComponent<BoxCollider2D>().size = new Vector2(borderWidth, width);

        border = Instantiate(borderPrefab, new Vector2(sizeX / 2 * width + width / 2, 0.0f), Quaternion.identity, Map);
        border.GetComponent<SpriteRenderer>().size = new Vector2(width, borderHeight);
        border.GetComponent<BoxCollider2D>().size = new Vector2(width, borderHeight);

        border = Instantiate(borderPrefab, new Vector2(0.0f, -(sizeY / 2 * width + width / 2)), Quaternion.identity, Map);
        border.GetComponent<SpriteRenderer>().size = new Vector2(borderWidth, width);
        border.GetComponent<BoxCollider2D>().size = new Vector2(borderWidth, width);

        border = Instantiate(borderPrefab, new Vector2(-(sizeX / 2 * width + width / 2), 0.0f), Quaternion.identity, Map);
        border.GetComponent<SpriteRenderer>().size = new Vector2(width, borderHeight);
        border.GetComponent<BoxCollider2D>().size = new Vector2(width, borderHeight);
    }

    void TerrainGenerate()
    {
        for(int x = -(sizeX / 2); x < sizeX / 2; x++)
        {
            for(int y = -(sizeY / 2); y < sizeY / 2; y++)
            {
                if(x == -(sizeX / 2) && y == sizeY / 2 - 1)
                {
                    continue;
                }

                int randomObjectNumber = Random.Range(0, mapObjects.Length);
                Instantiate(mapObjects[randomObjectNumber], new Vector2(x * width + width / 2, y * width + width / 2), Quaternion.identity, Map);
            }
        }
    }
}



