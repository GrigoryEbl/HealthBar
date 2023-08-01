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

    public readonly float MaxHealth = 100;
    private readonly float _minHealth = 0;

    public bool IsHealth { get; private set; }
    public bool IsDamage { get; private set; }
    public float CurrHealth { get; private set; }

    private void Awake()
    {
        CurrHealth = _health;
    }

    public void TakeHeal()
    {
        IsHealth = true;

        if ((_health + _heal) < MaxHealth)
        {
            _health += _heal;
            InstantiateHit(_heal, Color.green, '+');
        }
        else
        {
            _health = MaxHealth;
        }

        CurrHealth = _health;
    }

    public void TakeDamage()
    {
        IsDamage = true;

        if ((_health - _damage) > _minHealth)
        {
            _health -= _damage;
            InstantiateHit(_damage, Color.red, '-');
        }
        else
        {
            _health = _minHealth;
        }

        CurrHealth = _health;
    }

    private void InstantiateHit(float hit, Color color, char symbol)
    {
        _hit.text = hit.ToString() + symbol;
        _hit.color = color;
        Instantiate(_hit, _canvas.transform);
    }
}
