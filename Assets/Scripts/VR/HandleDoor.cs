using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDoor : MonoBehaviour
{
    private float RotationZ;
    public GameObject Door;
    public Material greenMat;
    
    private float startDoorRotation;
    public float AddRotation = 20f;

    public float RotationSpeed = 15f;
    public bool inverseSpeed = false;
    private int reverseSpeed= 1;
    public float angleDooor;
    public float endPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startDoorRotation = Door.transform.localEulerAngles.y;
        if(inverseSpeed == true)
        {
            reverseSpeed = -1;
        }
       
        endPos = startDoorRotation + AddRotation;
    }

    // Update is called once per frame
    void Update()
    {
        angleDooor = Door.transform.localEulerAngles.y;
        RotationZ = transform.localEulerAngles.z;
        if (RotationZ >= 90)
        {
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<MeshRenderer>().material = greenMat;
            if(Door.transform.localEulerAngles.y <= endPos)
            {
                Door.transform.localEulerAngles += new Vector3(0, 1*reverseSpeed, 0) * Time.deltaTime * RotationSpeed;
            }
        }
    }
}
