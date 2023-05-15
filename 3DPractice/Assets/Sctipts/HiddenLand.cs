using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
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
                StartCoroutine(OpenLands());
            }
        }
    }

    IEnumerator OpenLands()
    {
        foreach (Transform item in transform)
        {
            item.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }
}