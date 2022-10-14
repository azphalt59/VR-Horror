using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class torchlight : MonoBehaviour
{
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
        if(GetComponent<Light>().enabled == true)
        {
            GetComponent<Light>().enabled = false;
            return;
        }
        if (GetComponent<Light>().enabled == false)
        {
            GetComponent<Light>().enabled = true;
            return;
        }
    }
    public void Perform()
    {
        if (GetComponent<Light>().enabled == true)
        {
            GetComponent<Light>().enabled = false;
            return;
        }
        if (GetComponent<Light>().enabled == false)
        {
            GetComponent<Light>().enabled = true;
            return;
        }
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
