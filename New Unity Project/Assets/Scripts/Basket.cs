using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Basket : MonoBehaviour
{
    public event Action<Item> catchItem;
    [SerializeField] private string _treeTag;
    [SerializeField] private Stats _uIStats;
    [SerializeField] private AudioSource _audio;
    public Stats GetStats()
        => _uIStats;
    private void Update()
    {
        _audio = GetComponent<AudioSource>();
        var mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        var mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        var pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }
    public void UseItem(Item item)
    {
        if (item is GreenBottle)
        {
            transform.localScale *= 1.01f;
        }
        if (item is BlueBottle)
        {
            _uIStats.scorePerItem += 2;
        }
        Destroy(item.gameObject);

    }
    private void OnCollisionEnter(Collision coll)
    {
        var collItem = coll.gameObject.GetComponent<Item>();
        if (collItem is null)
        {
            return;
        }
        _audio.Play();
        catchItem?.Invoke(collItem);
        UseItem(collItem);
    }
}
