using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionToMovement : MonoBehaviour
{
    [SerializeField]
    private InputActionReference _vector2ActionReference;
    public InputActionReference Vector2ActionReference { get => _vector2ActionReference; set => _vector2ActionReference = value; }
    [SerializeField]
    private Rigidbody _XR_RigRigidbody;
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private Transform _mainCameraTransform;
    void Update()
    {
        if (Vector2ActionReference != null && Vector2ActionReference.action != null)
        {
            Vector2 padDirection = Vector2ActionReference.action.ReadValue<Vector2>();
            if (padDirection.magnitude > 0.001f)
            {
                Vector3 movementDirection = padDirection.x * _mainCameraTransform.right + padDirection.y * _mainCameraTransform.forward;
                Vector3 forceDirection = new Vector3(movementDirection.x, 0, movementDirection.z).normalized;
                _XR_RigRigidbody.AddForce(forceDirection * _speed, ForceMode.Acceleration);
                _XR_RigRigidbody.velocity = _XR_RigRigidbody.velocity.normalized * Mathf.Clamp(_XR_RigRigidbody.velocity.magnitude, 0, 5);
            }
        }
    }

}
