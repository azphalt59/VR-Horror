using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class torchlight : MonoBehaviour
{
    private bool EnabledL = false;
    [SerializeField]
    private InputActionReference lightAction;
    // Start is called before the first frame update

    private void OnEnable()
    {
        lightAction.action.performed += PerformLight;
    }

    private void PerformLight(InputAction.CallbackContext obj)
    {
        Debug.Log("primary button is pressed");
        if (EnabledL == false)
        {
            EnabledL = true;
            GetComponent<Light>().enabled = true;
            return;
        }
        if (EnabledL == true)
        {
            EnabledL = false;
            GetComponent<Light>().enabled = false;
            return;
        }
    }

    private void OnDisable()
    {
        lightAction.action.performed -= PerformLight;
    }
    
    void Start()
    {
        GetComponent<Light>().enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
      
    }
}
