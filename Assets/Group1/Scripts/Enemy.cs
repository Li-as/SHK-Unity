using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;

    public event UnityAction<Enemy> EnemyDied;

    private void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < _player.KillRange)
        {
            EnemyDied?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}
