using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _player.Health.OnChange.AddListener(OnHealthChanged);
    }

    private void OnHealthChanged(float newValue)
    {
        var value = newValue / _player.Health.Max;
        _image.fillAmount = value;

        var presents = Math.Round(value, 3) * 100;
        _text.text = presents.ToString(CultureInfo.CurrentCulture) + "%";
    }
}