using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _speedUpMultiplier = 2f;
    [SerializeField] private float _speedUpDuration = 2f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        transform.Translate(moveDirection * _speed * Time.deltaTime);
    }

    public void ActivateSpeedUp()
    {
        StartCoroutine(SpeedUpBonus());
    }

    private IEnumerator SpeedUpBonus()
    {
        _speed *= _speedUpMultiplier;
        yield return new WaitForSeconds(_speedUpDuration);
        _speed /= _speedUpMultiplier;
    }
}