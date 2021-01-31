using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _endScreen;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _enemiesContainer;

    private void OnEnable()
    {
        _player.EnemyKilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        _player.EnemyKilled -= OnEnemyKilled;
    }

    private void OnEnemyKilled()
    {
        Enemy[] enemies = _enemiesContainer.GetComponentsInChildren<Enemy>();
        if (enemies.Length == 0)
        {
            _endScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
