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
    [SerializeField] Rigidbody coin;

    [SerializeField] TMP_Text ScoreText;

    private int SpawnLoc; 

    public Movement movement;
    void Start()
    {
        ScoreText.text = $"Score: {Score}";
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Score++;
        ScoreText.text = $"Score: {Score}";
        SpawnLoc = Random.Range(1, 3);

        if (SpawnLoc == 1)
        {
            Rigidbody rb = Instantiate(coin, new Vector2(15f , -14.47f), Quaternion.Euler(0,0,0));
        }
        else if (SpawnLoc == 2)
        {
            Rigidbody rb = Instantiate(coin, new Vector2(15f, -14.47f), Quaternion.Euler(0, 0, 0));
        }
        else if (SpawnLoc == 3)
        {
            Rigidbody rb = Instantiate(coin, new Vector2(15f, -14.47f), Quaternion.Euler(0, 0, 0));
        }
    }
}
