using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class CoinSpawner : MonoBehaviour
{
    public int Score = 0;
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
        //Destroy(gameObject);
        Debug.Log("Coin Collected");
        Score++;
        UpdateScoreText();
        SpawnLoc = Random.Range(1, 4);
        Debug.Log(SpawnLoc);
        if (SpawnLoc == 1)
        {
            transform.position = spawnLoc1;
        }
        else if (SpawnLoc == 2)
        {
            transform.position = spawnLoc2;
        }
        else if (SpawnLoc == 3)
        {
            transform.position = spawnLoc3;
        }

        gameEvent.Raise();
    }

    public void UpdateScoreText()
    {
        ScoreText.text = $"Score: {Score}";
    }
}
