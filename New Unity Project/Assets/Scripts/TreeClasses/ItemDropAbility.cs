using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropAbility : MonoBehaviour
{
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private GameObject _greenBottlePrefab;
    [SerializeField] private GameObject _blueBottlePrefab;
    [SerializeField] private GameObject _redBottlePrefab;
    public GameObject DropItem()
    {
        var chance = Random.Range(0f, 1f);
        GameObject item;
        if (chance > 0.1f)
        {
            item = Instantiate(_applePrefab, transform.position, Quaternion.identity);
        }
        else
        {
            item = DropBottle(Random.Range(0, 3));
        }
        return item;
    }
    private GameObject DropBottle(int type)
    {
        switch (type)
        {
            case 0:
                return Instantiate(_greenBottlePrefab, transform.position, Quaternion.identity);
            case 1:
                return Instantiate(_blueBottlePrefab, transform.position, Quaternion.identity);
            case 2:
                return Instantiate(_redBottlePrefab, transform.position, Quaternion.identity);
            default:
                return null;
        }
    }
}
