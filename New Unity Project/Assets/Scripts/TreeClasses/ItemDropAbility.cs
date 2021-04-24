using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropAbility : MonoBehaviour
{
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private GameObject _greenBottlePrefab;
    [SerializeField] private GameObject _blueBottlePrefab;
    [SerializeField] private GameObject _redBottlePrefab;
    public void DropItem()
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
        switch (type)
        {
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
