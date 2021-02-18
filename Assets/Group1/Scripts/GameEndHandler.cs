using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameEndHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _endScreen;
    [SerializeField] private List<Enemy> _enemies;

    private void OnEnable()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.EnemyDied += OnEnemyDied;
        }
    }

    private void OnDisable()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.EnemyDied -= OnEnemyDied;
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.EnemyDied -= OnEnemyDied;
        _enemies.Remove(enemy);

        if (_enemies.Count == 0)
        {
            _endScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
