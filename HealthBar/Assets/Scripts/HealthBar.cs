using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent((typeof(Slider)))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Player _player;

    private float _time = 0.3f;
    private string _healthPointName = "HP";

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        ShowHealth(_player.CurrHealth);
        _slider.value = _player.CurrHealth / _player.MaxHealth;
    }

    private void FixedUpdate()
    {
        if(_player.IsHealth || _player.IsDamage)
        {
            StartCoroutine(ChangeHealth());
        }
    }

    private void ShowHealth(float value)
    {
        _text.text = value.ToString() + _healthPointName;
    }

    private IEnumerator ChangeHealth()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _player.CurrHealth / _player.MaxHealth, _time * Time.deltaTime);

        ShowHealth(_player.CurrHealth);

        yield return null;
    }
}
