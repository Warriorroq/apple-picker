using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stats : MonoBehaviour
{
    public int ScorePerItem {
        set
        {
            if (value < 0)
            {
                value = 1;
            }
            _scorePerItem = value;
        }
        get => _scorePerItem;
        
    }
    [SerializeField] private Basket _basket;
    [SerializeField] private decimal _score = 0;
    [SerializeField] private int _scorePerItem = 1;
    [SerializeField] private TextValue _scoreText;
    [SerializeField] private TextValue _hpText;
    [SerializeField] private decimal _hp = 5;
    public decimal Hp
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
            _hpText.UpdateText(_hp);
        }
    }
    void Start()
    {
        _basket.catchItem += CountItem;
    }
    private void CountItem(Item item)
    {
        _score += _scorePerItem;
        _scoreText.UpdateText(_score);
    }
}
