using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDoor : MonoBehaviour
{
    private float RotationZ;
    public GameObject Door;
    public Material greenMat;
    private Quaternion targetRotation;
    public float RotationSpeed = 15f;
    public float EndDoorRotation = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        targetRotation = Door.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        RotationZ = transform.localEulerAngles.z;
        if (RotationZ >= 90)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Door.GetComponent<MeshRenderer>().material = greenMat;
            if(Door.transform.localEulerAngles.y <= EndDoorRotation)
            {
                Door.transform.localEulerAngles += new Vector3(0, 1, 0) * Time.deltaTime * RotationSpeed;
            }
        }
    }
}
