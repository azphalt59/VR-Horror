using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class torchlight : MonoBehaviour
{
    [SerializeField]
    private InputActionReference lightActionLeft, lightActionRight;
    public bool isGrab = false;
    public bool inRealWorld = true;
    [SerializeField]
    private GameObject LightGameObject;
    // Start is called before the first frame update

    
    private void OnEnable()
    {
        lightActionLeft.action.performed += PerformLight;
        lightActionRight.action.performed += PerformLight; 
    }
    public void Grab()
    {
        isGrab = true;
    }
    public void Throw()
    {
        isGrab = false;
    }
    public void RealWorld()
    {
        inRealWorld = true;
    }
    public void DarkWorld()
    {
        inRealWorld = false;
    }
    public void UnlockDoors()
    {
        Main_Manager.Instance.ActiveDoor();
    }
    private void PerformLight(InputAction.CallbackContext obj)
    {
        
        if(isGrab == true)
        {
            if (LightGameObject.GetComponent<Light>().enabled == true)
            {
                LightGameObject.GetComponent<Light>().enabled = false;
                return;
            }
            if (LightGameObject.GetComponent<Light>().enabled == false)
            {
                LightGameObject.GetComponent<Light>().enabled = true;
                return;
            }
            
        }
    }
    
    public void Perform()
    {
        if (isGrab == true)
        {
            if (LightGameObject.GetComponent<Light>().enabled == true)
            {
                LightGameObject.GetComponent<Light>().enabled = false;
                return;
            }
            if (LightGameObject.GetComponent<Light>().enabled == false)
            {
                LightGameObject.GetComponent<Light>().enabled = true;

            }
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
        LightGameObject.GetComponent<Light>().enabled = false;
    }
}
