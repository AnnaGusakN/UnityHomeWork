using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, ITakeDamage, ITakeHealing
{
    public float speed = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private float _mouseSensetive = 90f;

    private int _boostDamage = 5;
    private Vector3 _direction = Vector3.zero;
    private float _angle;
    [SerializeField] private int _health = 100;


    void Update()
    {
        _direction.z = -Input.GetAxis("Vertical");

        _angle = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        var _speed = _direction.normalized * Time.fixedDeltaTime * speed;
        transform.Translate(_speed);
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0f, _angle * _mouseSensetive * Time.fixedDeltaTime, 0f));
    }

    private void Fire()
    {
        var bullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Booster(_boostDamage);
    }

    public void Damage(int damage)
    {
        if (_health > damage)
            _health -= damage;
        else
            Death();
    }

    private void Death()
    {
        Destroy(gameObject);
        Application.Quit();
    }

    public void Healing(int healing)
    {
        if (_health >= 100 - healing)
            _health = 100;
        else
            _health += healing;
    }
}
