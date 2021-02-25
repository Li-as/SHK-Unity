using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _speedMultiplier = 1;

    private void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        transform.Translate(direction * _speed * _speedMultiplier * Time.deltaTime);
    }

    public void ApplySpeedBoost(SpeedBoost boost)
    {
        StartCoroutine(WaitForEndOfSpeedBoost(boost));
    }

    private IEnumerator WaitForEndOfSpeedBoost(SpeedBoost boost)
    {
        _speedMultiplier *= boost.SpeedMultiplier;
        yield return new WaitForSeconds(boost.Duration);
        _speedMultiplier /= boost.SpeedMultiplier;
    }
}
