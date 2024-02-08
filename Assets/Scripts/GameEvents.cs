using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static UnityEvent SpawnCoin = new UnityEvent();
    public static UnityEvent<int> CollectCoin = new UnityEvent<int>();
}
