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

    public readonly float _maxHealth = 100;
    private readonly float _minHealth = 0;

    public float _currHealth { get; private set; }

    private void FixedUpdate()
    {
        _currHealth = _health;
    }

    public void TakeHeal()
    {
        if ((_health + _heal) < _maxHealth)
        {
            _health += _heal;
            InstantiateHit(_heal, Color.green, '+');
        }
        else
        {
            _health = _maxHealth;
        }
    }

    public void TakeDamage()
    {
        if ((_health - _damage) > _minHealth)
        {
            _health -= _damage;
            InstantiateHit(_damage, Color.red, '-');
        }
        else
        {
            _health = _minHealth;
        }
    }

    private void InstantiateHit(float hit, Color color, char symbol)
    {
        _hit.text = hit.ToString() + symbol;
        _hit.color = color;
        Instantiate(_hit, _canvas.transform);
    }
}
