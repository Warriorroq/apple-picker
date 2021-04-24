using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stats : MonoBehaviour
{
    public int Hp
    {
        get => _hp;
        set
        {
            if (value <= 0)
            {
                var scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }

            _hp = value;
            hpChange?.Invoke(_hp);
        }
    }
    public int scorePerItem = 10;
    public event Action<int> hpChange;
    public event Action<int> scoreResult;

    [SerializeField] private TextValue _scoreText;
    [SerializeField] private TextValue _hpText;
    [SerializeField] private Basket _basket;
    [SerializeField] private int _lastScore = 0;
    [SerializeField] private int _score = 0;
    [SerializeField] private int _hp = 5;

    void Start()
    {
        _basket.catchItem += CountItem;
        hpChange += _hpText.UpdateText;
    }
    private void CountItem(Item item)
    {
        _score += scorePerItem;
        if (_score - _lastScore == 100)
        {
            _lastScore = _score;
            scoreResult?.Invoke(_score);
        }
        _scoreText.UpdateText(_score);
    }
}
