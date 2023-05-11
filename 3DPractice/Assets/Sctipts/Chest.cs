using System;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.TryGetComponent(out PlayerController player);
    
            if (player.hasKey)
            {
                player.hasKey = false;
                _animator.SetTrigger("Open");                
            }
            else
            {
                Debug.Log("Come when you has key!!!");
            }
            
        }
    }
}
