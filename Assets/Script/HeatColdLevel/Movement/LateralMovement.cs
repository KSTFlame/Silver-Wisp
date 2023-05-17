using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AxisInputController), typeof(Rigidbody))]
public class LateralMovement : MonoBehaviour
{
    [SerializeField, Header("Statistics")]
    private float _speed = 1;
    
    private Rigidbody _rb;
    private AxisInputController _inputsController;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _inputsController = GetComponent<AxisInputController>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = new Vector3(_inputsController.Axis * _speed, _rb.velocity.y, _rb.velocity.z);
    }
}
