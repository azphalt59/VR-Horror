using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDoor : MonoBehaviour
{
    public GameObject Door;
    public GameObject otherKnob;
    public GameObject[] triggers;


    private float startDoorRotation;
    private Vector3 startKnobRotation;
    private Vector3 startOtherKnobRotation;
    
    public float AddRotation = 20f;

    public float RotationSpeed = 15f;
    [Range(1f,5f)]
    public float CloseSpeedMultiply = 1f;
    public bool inverseSpeed = false;
    private int reverseSpeed= 1;
    private float angleDoorY;
    private float endPos;
    private bool Open = false;
    private bool Close = true;
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        startDoorRotation = Door.transform.localEulerAngles.y;
        startKnobRotation = new Vector3(0, 0,transform.localEulerAngles.z);
        startOtherKnobRotation = new Vector3(0, otherKnob.transform.localEulerAngles.y, otherKnob.transform.localEulerAngles.z);


        if (inverseSpeed == true)
        {
            reverseSpeed = -1;
        }
       
        endPos = startDoorRotation + AddRotation;
    }

    // Update is called once per frame
    void Update()
    {
        angleDoorY  = Door.transform.localEulerAngles.y;
       

        if (transform.localEulerAngles.z >= 90)
        {
            triggers[0].SetActive(true);
            OpenDoor();
        }
        if (otherKnob.transform.localEulerAngles.z >= 90)
        {
            triggers[1].SetActive(true);
            OpenDoor();
        }
        if (angleDoorY <= startDoorRotation)
        {
            Close = true;
        }
        CloseDoor();
        
    }

    public void CloseDoorBoolean()
    {
        transform.localEulerAngles = startKnobRotation;
        otherKnob.transform.localEulerAngles = startOtherKnobRotation;
        triggers[0].SetActive(false);
        triggers[1].SetActive(false);
        Close = false;
    }
    public void CloseDoor()
    {
        if(angleDoorY > startDoorRotation && Close == false)
        {
            Door.transform.localEulerAngles -= new Vector3(0, 1 * reverseSpeed, 0) * Time.deltaTime * RotationSpeed * CloseSpeedMultiply;
        }
    }
    public void OpenDoor()
    {
        if (angleDoorY < endPos && Open == false)
        {
            Door.transform.localEulerAngles += new Vector3(0, 1 * reverseSpeed, 0) * Time.deltaTime * RotationSpeed;
        }
        if (angleDoorY >= endPos)
        {
            Open = true;
        }
    }

}


