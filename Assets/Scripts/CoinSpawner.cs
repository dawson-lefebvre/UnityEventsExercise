using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] coinPrefabs;
    Bounds bounds;
    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        bounds = boxCollider.bounds;
        GameEvents.SpawnCoin.AddListener(SpawnCoin);
    }

    void SpawnCoin()
    {
        GameObject c = Instantiate(coinPrefabs[Random.Range(0, coinPrefabs.Length)]);
        c.transform.position = GetRandomPoint();
    }

    Vector3 GetRandomPoint()
    {
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector3(randomX, randomY);
    }
}
