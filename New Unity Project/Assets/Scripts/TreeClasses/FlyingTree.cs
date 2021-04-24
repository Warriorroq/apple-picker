using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FlyingTree : MonoBehaviour
{
    [SerializeField] private float _secondsBetweenAppleDrops = 0.1f;
    [SerializeField] private ItemDropAbility _itemDrop;
    [SerializeField] private TreeMovement _treeMovement;
    [SerializeField] private Basket _basket;
    public event Action<GameObject> createItem;
    private void Start()
    {
        _itemDrop = GetComponent<ItemDropAbility>();
        _basket.catchItem += UseItem;
        InvokeRepeating(nameof(UseDropItems), _secondsBetweenAppleDrops, _secondsBetweenAppleDrops);
    }
    private void UseDropItems()
    {
        createItem?.Invoke(_itemDrop.DropItem());
    }
    private void UseItem(Item item)
    {
        _treeMovement.AddSpeed();
        if (item is RedBottle)
        {
            _treeMovement.speed /= 2;
        }
        else if(item is BlueBottle)
        {
            _secondsBetweenAppleDrops = UnityEngine.Random.Range(0.4f, 1.2f);
        }
        else if(item is GreenBottle)
        {
            _treeMovement.ChangeChanceOfChangeDirection();
        }
    }
}