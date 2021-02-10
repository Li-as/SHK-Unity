using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _movementRadius = 4;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = GetNewTargetPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (transform.position == _targetPosition)
            _targetPosition = GetNewTargetPosition();
    }

    private Vector3 GetNewTargetPosition()
    {
        return Random.insideUnitCircle * _movementRadius;
    }
}
