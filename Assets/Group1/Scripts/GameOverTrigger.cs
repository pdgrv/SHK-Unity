using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
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

        if (_enemies.Count <= 0)
            GameOver();
    }

    private void GameOver()
    {
        _gameOverScreen.SetActive(true);
    }
}
