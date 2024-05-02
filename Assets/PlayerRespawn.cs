using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform startPoint;
    public GameObject gameManager;
    private Vector2 lastCheckPoint;
    private bool haveCheckpoint = false;

    public void SaveCheckPoint(Vector2 checkpoint)
    {
        lastCheckPoint = checkpoint;
        haveCheckpoint = true;
    }
    public void Respawn()
    {

        if (haveCheckpoint != false)
        {
            transform.position = lastCheckPoint;
        } else
        {
            transform.position = startPoint.position;
        }
    }
}
