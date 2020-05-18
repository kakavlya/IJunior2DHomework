using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] Animator _animator;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            PlayCollecteAnimation();
            Destroy(gameObject, 0.5f);
        }
    }

    private void PlayCollecteAnimation()
    {
        _animator.SetTrigger("Collected");
    }
}
