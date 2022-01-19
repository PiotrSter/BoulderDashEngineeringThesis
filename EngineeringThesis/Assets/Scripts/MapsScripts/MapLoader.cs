using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapLoader : MonoBehaviour
{
    public string mapFile, path;
    public char separator;
    public float startX, startY, finishX, finishY;
    public string[] tab, data;
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
        path = Application.persistentDataPath + "\\" + mapFile;
    }

    void Start()
    {
        SaveMap();
        LoadMap();
    }

    void SaveMap()
    {
        if (!File.Exists(path))
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < data.Length; i++)
                    sw.WriteLine(data[i]);
            }
        }
    }

    void LoadMap()
    {
        using (StreamReader sr = new StreamReader(path))
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
            gm.howManyCoins++;
            return tabMapGameObject[3];
        }
        else
            return null;
    }
}
