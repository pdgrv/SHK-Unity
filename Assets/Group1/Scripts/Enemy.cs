using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _movementRadius = 4f;

    private Vector3 _movementPoint;

    public event UnityAction<Enemy> EnemyDied;

    private void Start()
    {
        _movementPoint = GetNextPoint();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _movementPoint, _speed * Time.deltaTime);

        if (transform.position == _movementPoint)
            _movementPoint = GetNextPoint();
    }

    private Vector2 GetNextPoint()
    {
        return Random.insideUnitCircle * _movementRadius;
    }

    public void Die()
    {
        EnemyDied?.Invoke(this);
        Destroy(gameObject);
    }
}
