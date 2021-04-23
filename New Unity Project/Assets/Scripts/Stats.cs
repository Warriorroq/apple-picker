using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stats : MonoBehaviour
{
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
    public int scorePerItem = 10;
    [SerializeField] private Basket _basket;
    [SerializeField] private decimal _lastScore = 0;
    [SerializeField] private decimal _score = 0;
    [SerializeField] private TextValue _scoreText;
    [SerializeField] private TextValue _hpText;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private decimal _hp = 5;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _basket.catchItem += CountItem;
    }
    private void CountItem(Item item)
    {
        _score += scorePerItem;
        if (_score - _lastScore == 100)
        {
            _lastScore = _score;
            _audio.Play();
        }
        _scoreText.UpdateText(_score);
    }
}
