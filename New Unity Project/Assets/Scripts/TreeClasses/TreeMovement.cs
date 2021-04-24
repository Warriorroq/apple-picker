using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{
    public float speed = 1f;
    [SerializeField] private float _additionalSpeedPerItem = 0.1f;
    [SerializeField] private float _chanceToChangeDirections = 0.1f;
    [SerializeField] private float _leftAndRightEdge = 10f;
    [SerializeField] private float _updateTimeToChangeDirections = 0.1f;
    private void Start()
    {
        InvokeRepeating(nameof(ChangeDirection), _updateTimeToChangeDirections, _updateTimeToChangeDirections);
    }
    public void AddSpeed()
    {
        if (speed >= 0)
        {
            speed += _additionalSpeedPerItem;
            return;
        }
        speed -= _additionalSpeedPerItem;
    }
    public void ChangeChanceOfChangeDirection() 
        => _chanceToChangeDirections = Random.Range(0.1f, 0.25f);
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        TouchEdges();
    }
    private void TouchEdges()
    {
        if (transform.position.x < -_leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (transform.position.x > _leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    private void ChangeDirection()
    {
        var change = Random.value * 10f;
        if (change < _chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
