using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionToRotation : MonoBehaviour
{
    [SerializeField]
    private InputActionReference _vector2ActionReference, _clickActionReference;
    public InputActionReference Vector2ActionReference { get => _vector2ActionReference; set => _vector2ActionReference = value; }
    public InputActionReference ClickActionReference { get => _clickActionReference; set => _clickActionReference = value; }
    [SerializeField]
    private Transform _XR_RigTransform;
    [SerializeField]
    private int _steps = 8;
    private void Start()
    {
        ClickActionReference.action.Enable();
        ClickActionReference.action.performed += SnapTurn;

    }
    void SnapTurn(InputAction.CallbackContext callbackContext)
    {
        if (Vector2ActionReference != null && Vector2ActionReference.action != null && ClickActionReference != null && ClickActionReference.action != null)
        {
            Vector2 padDirection = Vector2ActionReference.action.ReadValue<Vector2>();
            if (Mathf.Abs(padDirection.x) > 0.001f)
            {
                _XR_RigTransform.Rotate(Vector3.up * 360 / _steps * (padDirection.x > 0 ? 1 : -1));
            }
        }
    }
}
