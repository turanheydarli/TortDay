using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float dump;
    
    private PlayerController _player;

    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    void FixedUpdate()
    {
        transform.position =
            Vector3.Lerp(transform.position, _player.transform.position + offset, dump * Time.deltaTime);
    }
}