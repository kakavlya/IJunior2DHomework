using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Transform[] _wayPoints;
    private int _currentWaypoint;

    private void Update()
    {
        Transform target = _wayPoints[_currentWaypoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position,
            _speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            _currentWaypoint++;
            if (_currentWaypoint >= _wayPoints.Length)
                _currentWaypoint = 0;
        }

        UpdateDirection(transform.position, target.position);
    }

    private void UpdateDirection(Vector3 position, Vector3 targetPos)
    {
        _sprite.flipX = (position.x - targetPos.x > 0);
    }
}
