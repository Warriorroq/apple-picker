using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBottle : Item
{
    private float _coefficient = 0;
    private int _sideCoefficient = 1;
    public int sides = 3;
    private void Update()
    {
        DestroyOnY();
        CoefficientUpdate();
        transform.Translate(Mathf.Sin(Mathf.PI * _coefficient) * Time.deltaTime * sides,0,0);
    }
    private void CoefficientUpdate()
    {
        _coefficient += _sideCoefficient * Time.deltaTime;
        if (_coefficient > 1f)
        {
            _coefficient = 1f;
            _sideCoefficient = -1;
        }
        else if (_coefficient < 0f)
        {
            _sideCoefficient = 1;
            _coefficient = 0;
        }
    }
}
