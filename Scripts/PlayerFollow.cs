using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;
    public float parralax;
    public float offset;
    public float zPos;
    public bool verticalFollow = false;


    private float cameraHeight;


    private void Start()
    {
        cameraHeight = 2f * Camera.main.orthographicSize;
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x / parralax + offset, verticalFollow ? player.transform.position.y > cameraHeight ? player.position.y : transform.position.y :transform.position.y, zPos);
        if (verticalFollow && player.position.y < transform.position.y - cameraHeight / 2)
            transform.position = new Vector3(transform.position.x, 0f, zPos);
    }
}
