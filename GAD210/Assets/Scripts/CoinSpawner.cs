using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class CoinSpawner : MonoBehaviour
{
    private int Score = 0;
    [SerializeField] GameObject coin;

    [SerializeField] TMP_Text ScoreText;

    private int SpawnLoc;
    [SerializeField] private Vector2 spawnLoc1;
    [SerializeField] private Vector2 spawnLoc2;
    [SerializeField] private Vector2 spawnLoc3;


    public GameEventScriptable gameEvent;
    void Start()
    {
        ScoreText.text = $"Score: {Score}";
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Debug.Log("Coin Collected");
        Score++;
        //ScoreText.text = $"Score: {Score}";
        SpawnLoc = Random.Range(1, 3);

        if (SpawnLoc == 1)
        {
            GameObject rb = Instantiate(coin, spawnLoc1, Quaternion.Euler(0,0,0));
        }
        else if (SpawnLoc == 2)
        {
            GameObject rb = Instantiate(coin, spawnLoc2, Quaternion.Euler(0, 0, 0));
        }
        else if (SpawnLoc == 3)
        {
            GameObject rb = Instantiate(coin, spawnLoc3, Quaternion.Euler(0, 0, 0));
        }

        gameEvent.Raise();
    }
}
