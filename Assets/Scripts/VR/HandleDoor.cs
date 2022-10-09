using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDoor : MonoBehaviour
{
    public GameObject Door;
    public GameObject otherKnob;
    public GameObject meshKnob;
    public GameObject meshOtherKnob;
    public GameObject[] triggers;


    private float startDoorRotation;
   
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
    private bool isSelected = false;
    private bool isSelected2 = false;




    // Start is called before the first frame update
    void Start()
    {
        startDoorRotation = Door.transform.localEulerAngles.y;
        
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

        OpenDoor();
        CloseDoor();
    }

    public void CloseDoorBoolean()
    {
        triggers[0].SetActive(false);
        triggers[1].SetActive(false);
        isSelected2 = true;
    }
    public void CloseDoor()
    {
        if (isSelected2 == true)
        {
            if(angleDoorY > startDoorRotation)
            {
                Door.transform.localEulerAngles -= new Vector3(0, 1 * reverseSpeed, 0) * Time.deltaTime * RotationSpeed * CloseSpeedMultiply;
            }
            if(angleDoorY <= startDoorRotation)
            {
                isSelected2 = false;
            }
        }
    }
    public void OpenDoor()
    {
        if (isSelected == true)
        {
            if (angleDoorY < endPos)
            {
                Door.transform.localEulerAngles += new Vector3(0, 1 * reverseSpeed, 0) * Time.deltaTime * RotationSpeed;
            }
            if(angleDoorY >= endPos)
            {
                isSelected = false;
            }
        }
    }
    public void test()
    {
        Debug.Log("Test");
    }
    public void Selected()
    {
        isSelected = true;
    }
    public void UnSelected()
    {
        isSelected = false;
    }
    public void resetPosition()
    {
        transform.position = meshKnob.transform.position;
        meshOtherKnob.transform.position = meshOtherKnob.transform.position;
    }
}


