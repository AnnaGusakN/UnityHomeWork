using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurrel : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnTurrel1;
    [SerializeField] private float _time = 3f;

    private float _timer;
    private Transform _target;

    void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (_timer > _time)
        {
            _timer = 0f;
            var bullet = GameObject.Instantiate(bulletPrefab, bulletSpawnTurrel1.transform.position, Quaternion.identity).GetComponent<Bullet>();
            bullet.Target = _target;
        }

        else
        {
            _timer += Time.deltaTime;
        }
    }
    
}
