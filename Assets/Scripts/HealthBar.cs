using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _updateSpeed;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _incrementStep;
    private const float _defaultStartingHealth = 50f;
    private const int _defaultMaxHealth = 100;
    private const int _defaultStep = 10;
    private const int _defaultUpdateSpeed = 2;
    private float _updatedHealth;
    private float _health;

    private void Start()
    {
        _updatedHealth = _health = _defaultStartingHealth;
        _maxHealth = _maxHealth == 0 ? _defaultMaxHealth : _maxHealth;
        _incrementStep = _incrementStep == 0 ? _defaultStep : _incrementStep;
        _updateSpeed = _updateSpeed == 0 ? _defaultUpdateSpeed : _updateSpeed;
        _healthBar.value = _health;
    }

    private void Update()
    {
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        if (Mathf.Approximately(_updatedHealth, _health))
            return;

        _health = Mathf.Lerp(_health, _updatedHealth, Time.deltaTime * _updateSpeed);
        _healthBar.value = _health;
    }

    public void AddHealth()
    {
        if(_health <= _maxHealth)
            _updatedHealth = _health + _incrementStep;
    }

    public void ReduceHealth()
    {
        if(_health >= _minHealth)
            _updatedHealth = _health - _incrementStep;
    }
}
