using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    public bool timer;
    public float time;

    private void Update()
    {
        if (timer) //если вышел таймер скорость понижается вдвое
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                timer = false;
                _speed /= 2;
            }
        }

        Move();
    }

    private void Move()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertival"), 0);

        transform.Translate(moveDirection * _speed * Time.deltaTime);
    }

    public void SendMEssage(GameObject b)
    {
        if (b.name == "enemy")
        {
            Destroy(b);
        }
        if (b.name == "speed")
        {
            _speed *= 2;
            timer = true;
            time = 2;
        }
    }
}
