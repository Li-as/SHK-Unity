using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private List<Enemy> _enemies;

    private float _speedMultiplier = 1;

    public event UnityAction EnemyKilled;

    private void Update()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < 0.2f)
            {
                enemy.Die();
                EnemyKilled?.Invoke();
            }
        }

        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        transform.Translate(direction * _speed * _speedMultiplier * Time.deltaTime);
    }

    public void ApplyBoost(Boost boost)
    {
        if (boost is SpeedBoost speedBoost)
            _speedMultiplier *= speedBoost.SpeedMultiplier;

        StartCoroutine(WaitForEndOfBoost(boost));
    }

    private void RemoveBoost(Boost boost)
    {
        if (boost is SpeedBoost speedBoost)
            _speedMultiplier /= speedBoost.SpeedMultiplier;
    }

    private IEnumerator WaitForEndOfBoost(Boost boost)
    {
        float elapsedTime = 0;

        while (elapsedTime < boost.Duration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        RemoveBoost(boost);
        yield break;
    }
}
