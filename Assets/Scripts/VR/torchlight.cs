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
    private Light GetLight;
    public float SpeedIntensity =1f;
    private bool Downgrade = false;
    private bool Upgrade = false;
    [SerializeField]
    private float MaxIntensity;
    [SerializeField] private int FlashingLoop = 2;
    [SerializeField]
    private int currLoop = 0;
    private float SpeedMultiplier = 1f;
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
            if (GetLight.enabled == true)
            {
                GetLight.enabled = false;
                return;
            }
            if (GetLight.enabled == false)
            {
                GetLight.enabled = true;
                return;
            }
        }
    }
    public void Perform()
    {
    
    }
    private void OnDisable()
    {
        lightActionLeft.action.performed -= PerformLight;
        lightActionRight.action.performed -= PerformLight;
    }

    void Start()
    {
        GetLight = LightGameObject.GetComponent<Light>();
        GetLight.enabled = false;
        MaxIntensity = GetLight.intensity;
    }
    private void Update()
    {
        if(inRealWorld == false)
        {
            LowerAndUperIntensity();
        }
    }
    public void LowerAndUperIntensity()
    {
        if(currLoop < FlashingLoop)
        {
            if (GetLight.intensity <= 0)
            {
                Downgrade = false;
                Upgrade = true;
                currLoop++;
            }
            if (GetLight.intensity >= MaxIntensity)
            {
                Upgrade = false;
                Downgrade = true;
            }
            if (Upgrade)
            {
                HigherIntensity();
            }
            if (Downgrade)
            {
                LowerIntensity();
            }
        }
        if(currLoop == FlashingLoop)
        {
            GetLight.enabled = false;
        }
    }
    public void LowerIntensity()
    {
        if(currLoop == FlashingLoop - 1)
        {
            SpeedMultiplier = 0.04f;
        }
        else
        {
            SpeedMultiplier = 1f;
        }
        GetLight.intensity -= Time.deltaTime * SpeedIntensity * MaxIntensity * SpeedMultiplier;
    }
    public void HigherIntensity()
    {
        if(GetLight.intensity < MaxIntensity)
        {
            GetLight.intensity += Time.deltaTime * SpeedIntensity *MaxIntensity;
        }
    }
}
