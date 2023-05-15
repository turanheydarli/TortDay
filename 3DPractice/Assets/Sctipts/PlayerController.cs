using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public int item;

    [SerializeField] private float speed;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float smoothTurnTime;
    [SerializeField] private float attackDelay;

    [SerializeField] private FloatingJoystick _joystick;


    private float lastAttackTime;

    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private float _currentTurnAngle;

    public bool hasKey;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Time.time >= lastAttackTime + attackDelay)
        {
            Attack();
            lastAttackTime = Time.time;
        }

        _direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        _animator.SetFloat("Running", _direction.magnitude);

        if (_direction.magnitude > 0.01f)
        {
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentTurnAngle,
                0.3f);

            transform.rotation = Quaternion.Euler(0, angle, 0);

            _rigidbody.MovePosition(transform.position + (_direction.normalized * (speed * Time.deltaTime)));
        }
    }

    private void Attack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layer);

        foreach (var tree in colliders)
        {
            item++;
            tree.GetComponent<Tree>().Hit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sea"))
        {
            _animator.SetBool("IsSwimming", true);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("IsSwimming", false);
        }
    }
}