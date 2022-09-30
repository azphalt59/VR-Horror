using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class torchlight : MonoBehaviour
{
    private bool EnabledL = false;
    [SerializeField]
    private InputActionReference lightActionLeft, lightActionRight;
    // Start is called before the first frame update

    private void OnEnable()
    {
        lightActionLeft.action.performed += DisableLight;
        lightActionRight.action.performed += PerformLight;

        
    }

    private void PerformLight(InputAction.CallbackContext obj)
    {
        GetComponent<Light>().enabled = true;
    }
    private void DisableLight(InputAction.CallbackContext obj)
    {
        GetComponent<Light>().enabled = false;
    }


    private void OnDisable()
    {
        lightActionLeft.action.performed -= DisableLight;
        lightActionRight.action.performed -= PerformLight;
    }

    void Start()
    {
        GetComponent<Light>().enabled = false;
    }
}
