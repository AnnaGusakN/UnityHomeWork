using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 5;
    private Transform _target;
    private Vector3 _targetPosition;

    [SerializeField] private float _speed = 3f;

    public Transform Target
    {
        set
        {
            _target = value;
            _targetPosition = _target.position;
        }
    }

    void Start()
    {
        Destroy(gameObject, 15f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition + Vector3.up, Time.deltaTime);
    }
    public void Booster(int newDamage)
    {
        _damage = newDamage;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ITakeDamage>().Damage(_damage);
            Destroy(gameObject);
        }
    }
}
