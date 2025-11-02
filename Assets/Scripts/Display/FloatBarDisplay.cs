using Cysharp.Threading.Tasks;
using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.UI;
public class FloatBarDisplay : ValueDisplay<float>
{
    public override float DisplayValue { get; set; }
    private float ratio => DisplayValue / _maxValue;
    [SerializeField, Min(1)] private float _maxValue;
    [SerializeField] private Image _img;
    [SerializeField] private float _damp;
    public void Update()
    {
        _img.fillAmount = Mathf.Lerp(_img.fillAmount, DisplayValue / _maxValue, 1 - Mathf.Exp(-Time.deltaTime * _damp));
    }
}
