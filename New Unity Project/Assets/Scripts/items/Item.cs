using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float _bottomY = -20f;
    [SerializeField] private Vector3 _maxScatter;
    [SerializeField] private Vector3 _minScatter;
    [SerializeField] private Stats _stats;

    public void DestroyOnY()
    {
        if (transform.position.y < _bottomY)
        {
            _stats.Hp--;
            Destroy(gameObject);
        }
    }
    public void GetStats()
    {
        _stats = GameObject.FindGameObjectWithTag("UI").GetComponent<Stats>();
    }
    private void Start()
    {
        transform.position += new Vector3(Random.Range(_minScatter.x, _maxScatter.x), Random.Range(_minScatter.y, _maxScatter.y), 0);
        GetStats();
    }
    private void Update()
    {
        DestroyOnY();
    }
}
