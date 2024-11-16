using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public Transform SpawnPoint;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.position = SpawnPoint.position;
    }
}
