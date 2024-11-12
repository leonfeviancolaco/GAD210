using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public CoinSpawner Spawner;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.position = Vector2.zero;
        Spawner.Score = 0;
        Spawner.UpdateScoreText();
    }
}
