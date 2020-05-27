using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField]private Slider _healthBar;
    [SerializeField]private float _updateSpeed;
    private float _updatedHealth;
    private float _health;
    

    // Start is called before the first frame update
    private void Start()
    {
        _updatedHealth = _health = 50f;
        _healthBar.value = _health;
    }

    private void Update()
    {
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        if (Mathf.Approximately(_updatedHealth, _health))
            return;

        _health = Mathf.Lerp(_health, _updatedHealth, Time.deltaTime * _updateSpeed);
        _healthBar.value = _health;
    }

    public void AddHealth()
    {
        if(_health <= 100)
            _updatedHealth = _health + 10;
    }

    public void ReduceHealth()
    {
        if(_health >= 0)
            _updatedHealth = _health - 10;
    }
}
