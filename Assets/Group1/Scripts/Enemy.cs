using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction<Enemy> EnemyDied;

    public void Die()
    {
        EnemyDied?.Invoke(this);
        gameObject.SetActive(false);
    }
}
