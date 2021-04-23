using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingTree : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _additionalSpeedPerItem = 0.1f;
    [SerializeField] private float _leftAndRightEdge = 10f;
    [SerializeField] private float _chanceToChangeDirections = 0.1f;
    [SerializeField] private float _updateTimeToChangeDirections = 0.1f;
    [SerializeField] private float _secondsBetweenAppleDrops = 0.1f;
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private GameObject _greenBottlePrefab;
    [SerializeField] private GameObject _blueBottlePrefab;
    [SerializeField] private GameObject _redBottlePrefab;
    [SerializeField] private Basket _basket;
    private void Start()
    {
        _basket.catchItem += UseItem;
        InvokeRepeating(nameof(DropItem), _secondsBetweenAppleDrops, _secondsBetweenAppleDrops);
        InvokeRepeating(nameof(ChangeDirection), _updateTimeToChangeDirections, _updateTimeToChangeDirections);
    }
    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
        TouchEdges();
    }
    private void ChangeDirection()
    {
        var change = Random.value * 10f;
        if (change < _chanceToChangeDirections)
        {
            _speed *= -1;
        }
    }
    private void AddSpeed()
    {
        if(_speed >= 0)
        {
            _speed += _additionalSpeedPerItem;
            return;
        }
        _speed -= _additionalSpeedPerItem;
    }
    private void UseItem(Item item)
    {
        AddSpeed();
        if (item is RedBottle)
        {
            _speed /= 2;
        }
        else if(item is BlueBottle)
        {
            _secondsBetweenAppleDrops = Random.Range(0.1f, 1.2f);
        }
        else if(item is GreenBottle)
        {
            _chanceToChangeDirections = Random.Range(0.1f, 0.25f);
        }
    }
    private void TouchEdges()
    {
        if (transform.position.x < -_leftAndRightEdge)
        {
            _speed = Mathf.Abs(_speed);
        }
        else if (transform.position.x > _leftAndRightEdge)
        {
            _speed = -Mathf.Abs(_speed);
        }
    }
    private void DropItem()
    {
        var chance = Random.Range(0f, 1f);
        if (chance > 0.1f)
        {
            Instantiate(_applePrefab, transform.position, Quaternion.identity);
        }
        else
        {
            DropBottle(Random.Range(0, 3));
        }
    }
    private void DropBottle(int type)
    {
        switch (type) {
            case 0:
                Instantiate(_greenBottlePrefab, transform.position, Quaternion.identity);
                return;
            case 1:
                Instantiate(_blueBottlePrefab, transform.position, Quaternion.identity);
                return;
            case 2:
                Instantiate(_redBottlePrefab, transform.position, Quaternion.identity);
                return;
            default:
                return;
        }
    }
}