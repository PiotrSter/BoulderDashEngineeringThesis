using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform playerPosition, cameraPosition;
    private float cameraOffset;
    void Awake()
    {
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        cameraPosition = this.GetComponent<Transform>();
    }

    void Update()
    {
        cameraPosition.position = new Vector3(playerPosition.position.x, playerPosition.position.y, cameraPosition.position.z);
    }
}
