using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCloseDoor : MonoBehaviour
{
    public HandleDoor handleDoorScript;
    public bool HingeDoor = false;
    public GameObject Door;
    public float RotationSpeed;
    private float DoorRotationY;
    public GameObject FrontTrigger;
    public GameObject BehindTrigger;
    private bool canClose = false;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(GetComponent<MeshFilter>());
        //Destroy(GetComponent<MeshRenderer>());
        DoorRotationY = Door.transform.localEulerAngles.y;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(HingeDoor == false)
            {
                handleDoorScript.CloseDoorBoolean();
            }
            if(HingeDoor == true)
            {
                canClose = true;
                FrontTrigger.SetActive(false);
                BehindTrigger.SetActive(false);
            }
        }
    }
    private void Update()
    {
        if(canClose == true)
        {
            CloseTheDoor();
        }
        
    }
    public void CloseTheDoor()
    {
        if(DoorRotationY < Door.transform.localEulerAngles.y -1)
        {
            Door.transform.localEulerAngles += new Vector3(0, 1, 0) * Time.deltaTime * RotationSpeed;
        }
        if (DoorRotationY > Door.transform.localEulerAngles.y +1)
        {
            Door.transform.localEulerAngles -= new Vector3(0, 1, 0) * Time.deltaTime * RotationSpeed;
        }
        if(DoorRotationY <= Door.transform.localEulerAngles.y -1 || DoorRotationY >= Door.transform.localEulerAngles.y +1)
        {
            canClose = false;
        }

    }



}
