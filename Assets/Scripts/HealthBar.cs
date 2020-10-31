using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]private Slider _healthBar;
    [SerializeField]private float _updateSpeed;
    [SerializeField]private float _minHealth;
    [SerializeField]private float _maxHealth;
    [SerializeField]private float _incrementStep;
    private float _updatedHealth;
    private float _health;

    private void Start()
    {
        _updatedHealth = _health = 50f;
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
