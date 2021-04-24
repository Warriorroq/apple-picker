using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceResult;
    [SerializeField] private AudioSource _audioSourceHp;
    [SerializeField] private AudioSource _audioSourceItem;
    [SerializeField] private AudioSource _audioSourceBasket;
    [SerializeField] private Basket _basket;
    [SerializeField] private FlyingTree _tree;
    [SerializeField] private Stats _stats;
    private void Start()
    {
        _basket.catchItem += CatchSound;
        _tree.createItem += CreateItemSound;
        _stats.hpChange += HpSound;
        _stats.scoreResult += ScoreResultSound;
    }

    private void ScoreResultSound(int obj)
    {
        PlaySound(_audioSourceResult);
    }

    private void HpSound(int obj)
    {
        PlaySound(_audioSourceHp);
    }

    private void CreateItemSound(GameObject obj)
    {
        PlaySound(_audioSourceItem);
    }

    private void CatchSound(Item obj)
    {
        PlaySound(_audioSourceBasket);
    }
    private void PlaySound(AudioSource source)
    {
        source.Play();
    }
}
