using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    public bool isEvil = false;

    private void Start()
    {
        if (isEvil)
        {
            Invoke("Die", 10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameEvents.CollectCoin.Invoke(value);
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
