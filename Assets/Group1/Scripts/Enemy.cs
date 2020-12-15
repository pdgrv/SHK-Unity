using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _movementRadius = 4f;
    [SerializeField] private float _collisionRange = 0.2f;

    private Vector3 _target;
    private Player _player;

    public event UnityAction<Enemy> EnemyDied;

    private void Start()
    {
        _player = FindObjectOfType<Player>();

        _target = GetRandomPoint();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            _target = GetRandomPoint();

        if (Vector3.Distance(transform.position, _player.transform.position) < _collisionRange)
            Die();
    }

    private Vector2 GetRandomPoint()
    {
        return Random.insideUnitCircle * _movementRadius;
    }

    private void Die()
    {
        EnemyDied?.Invoke(this);
        Destroy(gameObject);
    }
}