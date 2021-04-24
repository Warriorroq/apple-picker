using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _resultScore;
    [SerializeField] private AudioClip _createItem;
    [SerializeField] private AudioClip _hpSound;
    [SerializeField] private AudioClip _takeItem;
    [SerializeField] private AudioSource _audioSource;
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
        PlaySound(_resultScore);
    }

    private void HpSound(int obj)
    {
        PlaySound(_hpSound);
    }

    private void CreateItemSound(GameObject obj)
    {
        PlaySound(_createItem);
    }

    private void CatchSound(Item obj)
    {
        PlaySound(_takeItem);
    }
    private void PlaySound(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
