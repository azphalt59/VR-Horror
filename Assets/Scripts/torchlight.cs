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
        lightActionLeft.action.performed += PerformLight;
        lightActionRight.action.performed += PerformLight;
    }

    private void PerformLight(InputAction.CallbackContext obj)
    {
        if (EnabledL == false)
        {
            EnabledL = true;
            GetComponent<Light>().enabled = true;
            return;
        }
        /*
        if (EnabledL == true)
        {
            EnabledL = false;
            GetComponent<Light>().enabled = false;
            return;
        }
        */
    }

    private void OnDisable()
    {
        lightActionLeft.action.performed -= PerformLight;
        lightActionRight.action.performed -= PerformLight;
    }

    void Start()
    {
        GetComponent<Light>().enabled = false;
    }
}
