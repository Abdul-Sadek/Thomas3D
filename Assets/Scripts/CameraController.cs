using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(-3, 1, 0);
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
