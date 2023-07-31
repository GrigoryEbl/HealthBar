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
    private float _health;
    private float _maxHealth;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
         _health = _player._currHealth;
        _maxHealth = _player._maxHealth;

        _slider.value = Mathf.MoveTowards(_slider.value, _health / _maxHealth, _time * Time.deltaTime);

        ShowHealth(_health);
    }

    private void ShowHealth(float value)
    {
        _text.text = value.ToString() + "hp";
    }
}
