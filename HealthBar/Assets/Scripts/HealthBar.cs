using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent((typeof(Slider)))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Player _player;
    [SerializeField] private float _time;

    private string _healthPointName = "HP";

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        ShowHealth(_player.CurrHealth);
        _slider.value = _player.CurrHealth / _player.MaxHealth;
    }

    public IEnumerator ChangeHealth()
    {
        ShowHealth(_player.CurrHealth);

        while (_slider.value != _player.CurrHealth / _player.MaxHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _player.CurrHealth / _player.MaxHealth, _time * Time.deltaTime);

            yield return null;
        }
    }

    private void ShowHealth(float value)
    {
        _text.text = value.ToString() + _healthPointName;
    }
}
