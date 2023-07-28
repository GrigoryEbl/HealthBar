using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _heal;
    [SerializeField] private float _damage;

    private float _maxHealth = 100;
    private float _minHealth = 0;

    private bool _isHeal = false;
    private bool _isDamage = false;

    public void TakeHeal()
    {
        _isHeal = true;

        if ((_health + _heal) < _maxHealth)
        {
            _health += _heal;
        }
        else
        {
            _health = _maxHealth;
        }

        Debug.Log("Health = " +  _health);
    }

    public void TakeDamage()
    {
        _isDamage = true;

        if((_health - _damage) > _minHealth)
        {
            _health -= _damage;
        }
        else
        {
            _health = _minHealth;
        }

        Debug.Log("Health = " +  _health);
    }

    public float GetHealth()
    {
       return _health;
    }

    public float GetMaxHealth()
    {
        return _maxHealth;
    }
}
