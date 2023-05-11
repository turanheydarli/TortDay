using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenLand : MonoBehaviour
{
    [SerializeField] private int price;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (price <= player.item)
            {
                foreach (Transform item in transform)
                {
                    item.gameObject.SetActive(true);
                }
            }
        }
    }
}