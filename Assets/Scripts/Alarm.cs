using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField]private UnityEvent _alarmEvent;
    [SerializeField]private AudioSource _alarmSound;
    [SerializeField]private float _ringingChangeTime;

    private bool _isRinging;
    private float _ringingTime;
    private bool _volumeIsRising;

    private void Start()
    {
        _ringingTime = 0;
        _isRinging = false;
        _volumeIsRising = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            TriggerAlarm();
        }
    }

    private void TriggerAlarm()
    {
        _isRinging = !_isRinging;
        if (_isRinging)
        {
            _alarmSound.Play();
        }
        else
        {
            ResetRingingTime();
            _alarmSound.Stop();
        }

    }

    private void ResetRingingTime()
    {
        _ringingTime = 0;
    }

    private void Update()
    {
        if (_isRinging)
        {
            if(_volumeIsRising)
            {
                _ringingTime += Time.deltaTime;
                if (_ringingTime >= _ringingChangeTime)
                {
                    _volumeIsRising = false;
                }
            }
            else {
                _ringingTime -= Time.deltaTime;
                if (_ringingTime <= 0)
                {
                    _volumeIsRising = true;
                }
            }
            AdjustVolume();
        }
    }

    private void AdjustVolume()
    {
        _alarmSound.volume = _ringingTime / _ringingChangeTime;
    }
}
