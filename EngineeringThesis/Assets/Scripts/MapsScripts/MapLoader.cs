using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapLoader : MonoBehaviour
{
    public string mapFile;
    public char separator;
    public float startX, startY, finishX, finishY;
    public string[] tab;
    public GameObject[] tabMapGameObject = new GameObject[4];
    public Transform map;
    GameManager gm;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        startX = gm.startX;
        finishX = gm.finishX;
        startY = gm.startY;
        finishY = gm.finishY;
    }

    void Start()
    {
        LoadMap();
    }

    void LoadMap()
    {
        using (StreamReader sr = new StreamReader(mapFile))
        {
            float y = startY;
            while (!sr.EndOfStream)
            {
                string tmp = sr.ReadLine();
                tab = tmp.Split(separator);

                float x = startX;

                foreach(string value in tab)
                {
                    GameObject mapGameObject = SetGameObject(value);
                    if (mapGameObject != null)
                        Instantiate(mapGameObject, new Vector2(x, y), Quaternion.identity, map);
                    else
                    {
                        if (x < finishX)
                            x += 1;
                        continue;
                    }

                    if (x < finishX)
                        x += 1;
                }

                if (y > finishY)
                    y -= 1;
            }
        }
    }

    private GameObject SetGameObject(string symbol)
    {
        if (symbol == "b")
            return tabMapGameObject[0];
        else if (symbol == "d")
            return tabMapGameObject[1];
        else if (symbol == "r")
            return tabMapGameObject[2];
        else if (symbol == "c")
        {
            gm.howManyCoin++;
            return tabMapGameObject[3];
        }
        else
            return null;
    }
}
