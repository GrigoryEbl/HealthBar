using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _heal;
    [SerializeField] private float _damage;
    [SerializeField] private TMP_Text _hit;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private HealthBar _healthBar;

    public readonly float MaxHealth = 100;
    private readonly float _minHealth = 0;


    public float CurrHealth { get; private set; }

    private void Awake()
    {
        CurrHealth = _health;
    }

    public void TakeHeal()
    {
        _health = Mathf.Clamp(_health += _heal, _minHealth, MaxHealth);

        if (_health > CurrHealth)
        {
            InstantiateHit(_heal, Color.green, '+');
        }

        CurrHealth = _health;

        _healthBar.StartCoroutine(_healthBar.ChangeHealth());
    }

    public void TakeDamage()
    {
        _health = Mathf.Clamp(_health -= _damage, _minHealth, MaxHealth);

        if (_health < CurrHealth)
        {
            InstantiateHit(_damage, Color.red, '-');
        }

        CurrHealth = _health;

        _healthBar.StartCoroutine(_healthBar.ChangeHealth());
    }

    private void InstantiateHit(float hit, Color color, char symbol)
    {
        _hit.text = hit.ToString() + symbol;
        _hit.color = color;
        Instantiate(_hit, _canvas.transform);
    }
}
